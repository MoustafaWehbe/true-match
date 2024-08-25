using Bogus;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

public class SeedRandomData
{
    private readonly ApplicationDBContext _context;
    private readonly Faker _faker;
    private readonly Random _random = new Random();

    public SeedRandomData(ApplicationDBContext context)
    {
        _context = context;
        _faker = new Faker();
    }

    public async Task SeedAsync(int userCount = 100, int roomCount = 50, int maxParticipantsPerRoom = 10)
    {
        var interests = await _context.Interests.ToListAsync();
        var lifeStyles = await _context.LifeStyles.ToListAsync();

        var users = GenerateUsers(userCount);
        for (int i = 0; i < userCount; i++)
        {
            var user = users[i];
            var profile = CreateRandomUserProfile(user.Id);
            profile.UserProfileInterests = GenerateRandomUserProfileInterests(interests, profile.Id);
            profile.UserProfileLifeStyles = GenerateRandomUserProfileLifeStyles(lifeStyles, profile.Id);
            user.UserProfile = profile;
            user.Media = CreateRandomMedia(user.Id);
            await _context.Users.AddAsync(user);
        }
        await _context.SaveChangesAsync();

        var rooms = GenerateRooms(roomCount);
        await _context.Rooms.AddRangeAsync(rooms);
        await _context.SaveChangesAsync();

        var participants = GenerateRoomParticipants(rooms, maxParticipantsPerRoom);
        await _context.RoomParticipants.AddRangeAsync(participants);
        await _context.SaveChangesAsync();
    }


    private UserProfile CreateRandomUserProfile(string userId)
    {
        return new UserProfile
        {
            UserId = userId,
            Gender = (Gender)_random.Next(0, 2),
            Nationality = _faker.Address.Country(),
            PlaceToLive = _faker.Address.City(),
            Bio = _faker.Lorem.Sentence(10),
            Height = (decimal)(_random.Next(150, 200) + _random.NextDouble()),
            RelationshipGoal = _faker.Lorem.Word(),
            Education = _faker.Lorem.Word(),
            Zodiac = _faker.Lorem.Word(),
            LoveStyle = _faker.Lorem.Word(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    private List<Media> CreateRandomMedia(string userId)
    {
        int mediaCount = _random.Next(1, 5);
        var mediaList = new List<Media>();

        for (int i = 0; i < mediaCount; i++)
        {
            mediaList.Add(new Media
            {
                Url = _faker.Image.PicsumUrl(),
                MediaType = (MediaType)_random.Next(0, 2),
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        }

        return mediaList;
    }

    private List<UserProfileInterest> GenerateRandomUserProfileInterests(List<Interest> interests, int profileId)
    {
        int count = _random.Next(1, 4);
        return interests.OrderBy(x => _random.Next())
            .Take(count)
            .Select(interest => new UserProfileInterest
            {
                UserProfileId = profileId,
                InterestId = interest.Id
            }).ToList();
    }

    private List<UserProfileLifeStyle> GenerateRandomUserProfileLifeStyles(List<LifeStyle> lifeStyles, int profileId)
    {
        int count = _random.Next(1, 3);
        return lifeStyles.OrderBy(x => _random.Next())
            .Take(count)
            .Select(lifeStyle => new UserProfileLifeStyle
            {
                UserProfileId = profileId,
                LifeStyleId = lifeStyle.Id
            }).ToList();
    }


    private List<User> GenerateUsers(int count)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.UserName, (f, u) => u.Email);

        return faker.Generate(count);
    }

    private List<Room> GenerateRooms(int count)
    {
        var users = _context.Users.ToList();

        var faker = new Faker<Room>()
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
            .RuleFor(r => r.Status, f => f.PickRandom<RoomStatus>())
            .RuleFor(r => r.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .RuleFor(r => r.UpdatedAt, f => f.Date.Recent().ToUniversalTime())
            .RuleFor(r => r.ScheduledAt, f => f.Date.Future().ToUniversalTime())
            .RuleFor(r => r.User, f => f.PickRandom(users));

        return faker.Generate(count);
    }

    private List<RoomParticipant> GenerateRoomParticipants(List<Room> rooms, int maxParticipantsPerRoom)
    {
        var users = _context.Users.ToList();
        var participants = new List<RoomParticipant>();

        foreach (var room in rooms)
        {
            var participantCount = new Random().Next(1, maxParticipantsPerRoom);
            var selectedUsers = new Faker().PickRandom(users, participantCount).ToList();

            participants.AddRange(selectedUsers.Select(user => new RoomParticipant
            {
                RoomId = room.Id,
                UserId = user.Id,
                AttendedFromTime = DateTime.UtcNow.AddMinutes(-new Random().Next(0, 120)), // Random join time within 2 hours
                AttendedToTime = DateTime.UtcNow.AddMinutes(new Random().Next(0, 60))   // Random leave time within 1 hour
            }));
        }

        return participants;
    }
}
