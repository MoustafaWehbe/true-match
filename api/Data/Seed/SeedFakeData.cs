using Bogus;
using api.Models;
using api.Data;

public class SeedFakeData
{
    private readonly ApplicationDBContext _context;
    private readonly Faker _faker;
    private readonly Random _random = new Random();

    public SeedFakeData(ApplicationDBContext context)
    {
        _context = context;
        _faker = new Faker();
    }

    public async Task SeedAsync(int userCount = 100, int roomCount = 50, int maxParticipantsPerRoom = 10)
    {
        if (!_context.Users.Any())
        {
            var users = GenerateUsers(userCount);
            for (int i = 0; i < userCount; i++)
            {
                var user = users[i];
                var profile = CreateRandomUserProfile(user.Id);
                user.UserProfile = profile;
                user.Media = CreateRandomMedia(user.Id);
                await _context.Users.AddAsync(user);
            }
            await _context.SaveChangesAsync();
        }

        if (!_context.Rooms.Any())
        {
            var rooms = GenerateRooms(roomCount);
            await _context.Rooms.AddRangeAsync(rooms);
            await _context.SaveChangesAsync();
            var participants = GenerateRoomParticipants(rooms, maxParticipantsPerRoom);
            await _context.RoomParticipants.AddRangeAsync(participants);
            await _context.SaveChangesAsync();
            var participantEvents = GenerateRoomParticipantEvents(participants, 2);
            await _context.RoomParticipantEvents.AddRangeAsync(participantEvents);
            await _context.SaveChangesAsync();
        }
    }


    private UserProfile CreateRandomUserProfile(string userId)
    {
        return new UserProfile
        {
            UserId = userId,
            Job = _faker.Address.Country(),
            School = _faker.Address.City(),
            Bio = _faker.Lorem.Sentence(10),
            BirthDate = _faker.Date.Past(20).ToUniversalTime(),
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
            .RuleFor(r => r.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .RuleFor(r => r.UpdatedAt, f => f.Date.Recent().ToUniversalTime())
            .RuleFor(r => r.ScheduledAt, f => f.Date.Future().ToUniversalTime())
            .RuleFor(r => r.User, f => f.PickRandom(users))
            .RuleFor(r => r.StartedAt, (f, r) =>
            {
                // Sometimes StartedAt is null
                return f.Random.Bool() ? null : f.Date.Past().ToUniversalTime();
            })
            .RuleFor(r => r.FinishedAt, (f, r) =>
            {
                // FinishedAt can be null, and if it's not null, StartedAt must not be null
                if (f.Random.Bool())
                {
                    return null;
                }
                else
                {
                    if (r.StartedAt == null)
                    {
                        r.StartedAt = f.Date.Past().ToUniversalTime(); // Ensure StartedAt is set
                    }
                    return f.Date.Future().ToUniversalTime();
                }
            });

        return faker.Generate(count);
    }

    private List<RoomParticipant> GenerateRoomParticipants(List<Room> rooms, int maxParticipantsPerRoom)
    {
        var users = _context.Users.ToList();
        var participants = new List<RoomParticipant>();

        foreach (var room in rooms)
        {
            var participantCount = new Random().Next(1, maxParticipantsPerRoom);
            var selectedUsers = _faker.PickRandom(users, participantCount).ToList();

            participants.AddRange(selectedUsers.Select(user => new RoomParticipant
            {
                RoomId = room.Id,
                UserId = user.Id,
            }));
        }

        return participants;
    }

    private List<RoomParticipantEvent> GenerateRoomParticipantEvents(List<RoomParticipant> roomParticipants, int maxParticipantEventsPerParticipant)
    {
        var participants = _context.RoomParticipants.ToList();
        var participantEvents = new List<RoomParticipantEvent>();

        foreach (var room in roomParticipants)
        {
            var participantEventCount = new Random().Next(1, maxParticipantEventsPerParticipant);
            var selectedParticipants = _faker.PickRandom(participants, participantEventCount).ToList();

            participantEvents.AddRange(selectedParticipants.Select(participant => new RoomParticipantEvent
            {
                AttendedFromTime = DateTime.UtcNow.AddMinutes(-new Random().Next(0, 120)), // Random join time within 2 hours
                AttendedToTime = DateTime.UtcNow.AddMinutes(new Random().Next(0, 60)),   // Random leave time within 1 hour
                Left = _faker.Random.Bool(),
                RoomParticipantId = participant.Id
            }));
        }

        return participantEvents;
    }
}