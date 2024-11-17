using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Text.Json;

namespace api.Data
{
    public static class SeedDataOnModelCreation
    {
        public static void Seed(ModelBuilder builder)
        {
            seedRoles(builder);
            seedQuestionsAndQuestionCategories(builder);
            seedRoomContent(builder);
            seedGenders(builder);
            seedAvailableDescriptors(builder);
        }

        private static void seedRoomContent(ModelBuilder builder)
        {
            builder.Entity<RoomContent>().HasData(new List<RoomContent> {
                new RoomContent{Id = Guid.NewGuid(), Title = "Meet & Greet", Description = "Give us the scoop on the person behind the screen!", Duration = 1 * 60, Order = 1},
                new RoomContent{Id = Guid.NewGuid(), Title = "Hobby Showcase & Fun Fact Extravaganza", Description = "Share your passions and two quirky facts about yourself!", Duration = 2 * 60, Order = 2},
                new RoomContent{Id = Guid.NewGuid(), Title = "Random Question Roulette", Description = "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", Duration = 5 * 60, Order = 3},
                new RoomContent{Id = Guid.NewGuid(), Title = "Spotlight Q&A", Description = "Get ready to field questions from your adoring audience!", Duration = 5 * 60, Order = 4},
                new RoomContent{Id = Guid.NewGuid(), Title = "The Final Rose", Description = "Pop your best question to the remaining contenders, and whoever nails it gets the match!", Duration = 60, Order = 5}
            });
        }

        private static void seedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
            });
        }

        private static void seedQuestionsAndQuestionCategories(ModelBuilder builder)
        {
            // Seed question categories
            var sexualCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Sexual" };
            var funnyCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Funny" };
            var flirtyCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Flirty" };
            var edgyCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Edgy" };
            var connectionBuildingCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Connection-building" };
            var dilemmaCategory = new QuestionCategory { Id = Guid.NewGuid(), Name = "Dilemma" };

            builder.Entity<QuestionCategory>().HasData(new List<QuestionCategory>
            {
                sexualCategory,
                funnyCategory,
                flirtyCategory,
                edgyCategory,
                connectionBuildingCategory,
                dilemmaCategory,
            });

            // builder.Entity<QuestionCategory>().OwnsMany(qc => qc.SystemQuestions).HasData(new List<SystemQuestion>

            // Seed system questions
            builder.Entity<SystemQuestion>().HasData(new List<SystemQuestion>
            {
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What physical act gives you the most pleasure?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you prefer firm or light touches?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do guy-on-guy videos turn you on more than guy-on-girl?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you think it’s okay if a guy wants to be submissive in the bedroom?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather receive or give oral?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you prefer to make out with the lights on or off?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather end a good first date with a passionate kiss or sex?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Are you more dominant or submissive in bed?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you fantasize about when you touch yourself?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you like to roleplay?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Have you ever had sex with someone you just met?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the dirtiest thought you’ve ever had about a stranger?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What does your ideal one-night stand look like?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If a cute couple asked you to do a threesome, would you say yes?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What are your thoughts on toys?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the dirtiest thing someone said to you during sex?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Where do you like to be touched most?", CategoryId = sexualCategory.Id },

                // Funny
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What meal or snack will you never refuse?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Zombies are overrunning the world. How do you defend yourself?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the weirdest thing you carry in your purse?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What was the last time you went skinny dipping?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you date someone who’s cute but mega dumb?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the last time you did something scary?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "You have to assassinate someone who really deserves it. How do you do it?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If your friends and family hear that you were arrested, what would they think you did?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "You and all your friends have to enter a mixed martial arts tournament. Do you win?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "You find out your best friend is a lesbian and she’s in love with you. How do you react?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you prefer the smell of freshly cut grass or freshly baked bread?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", CategoryId = funnyCategory.Id },

                // Flirty
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s your favorite way to be seduced by a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you miss most about being single? (She has to pick something.)", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the best romantic surprise you’ve ever had?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you find the most attractive in a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What does good sex mean to you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What are your biggest turn-offs?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you think is the most important thing a woman can give to a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What makes you feel sexy?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the hottest thing a guy can do for you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Can you surrender to love or is it something that scares you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Do you prefer cuddling or kissing?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you wear when you go to sleep?", CategoryId = flirtyCategory.Id },

                // Edgy
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather have a cat with a human face or a dog with human hands?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather speak every language fluently or play every instrument perfectly?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather Win $50,000 or let your best friend win $500,000?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather be stung by a thousand bees or stomp a kitten?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", CategoryId = edgyCategory.Id },

                // Connection-building
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Name three things that you can do to get out of a funk.", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s a recent book you read or movie you saw that taught you something?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you rather travel to the past or the future?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you could make one decision to change the world, what would you do?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the first thing you do when you get back home from work?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you could ask your pet 3 questions, what would they be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s something you’d like to be remembered for?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Is there a way you could fall head over heels for a man? What would that look like?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the most romantic thing you’ve ever done for someone?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you were the mayor of your city, what rule would you instantly enforce?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s your favorite and least favorite household chore?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s one responsibility of yours that you’d prefer to delegate to a professional?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s something you’ve always wanted to do, but haven’t?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Would you continue working if you were rich and didn’t need to?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What does your ideal night look like? Do you go out or are you at home with friends?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you could change one thing about the way you were raised, what would that be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s something that gives your life meaning?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What dating advice would you give your younger self?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What song would you want to play on your wedding day?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What would you like to get for your birthday?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "If you could only put on one piece of makeup, what would it be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the one compliment you get the most?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Where do you feel the most at home?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you wish you cared less about?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do your friends and family call you?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Where do you go if you want to escape?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s something you swear by?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What’s the most important thing your life is missing?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "What do you wish more people knew about you?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "How long ago did you tell someone you loved them?", CategoryId = connectionBuildingCategory.Id },

                // Dilemma
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Flight or invisibility?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Peanut butter or Nutella?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Quit coffee or never have snacks during films and series?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Bath or shower?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Love or money?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Burger or pizza?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = Guid.NewGuid(), Name = "Dine-in or delivery?", CategoryId = dilemmaCategory.Id }
            });
        }

        private static void seedGenders(ModelBuilder builder)
        {
            Guid manUid = Guid.NewGuid();
            Guid womanUid = Guid.NewGuid();
            Guid bbUid = Guid.NewGuid();

            builder.Entity<Gender>().HasData(
                new Gender { Id = manUid, Name = "Man", ParentId = null },
                new Gender { Id = womanUid, Name = "Woman", ParentId = null },
                new Gender { Id = bbUid, Name = "Beyond binary", ParentId = null },

                new Gender { Id = Guid.NewGuid(), Name = "Cis man", Description = "A man whose gender aligns with the sex they were assigned at birth.", ParentId = manUid },
                new Gender { Id = Guid.NewGuid(), Name = "Intersex man", Description = "A man born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = manUid },
                new Gender { Id = Guid.NewGuid(), Name = "Trans man", Description = "A man whose gender is different from his sex assigned at birth.", ParentId = manUid },
                new Gender { Id = Guid.NewGuid(), Name = "Transmasculine", Description = "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", ParentId = manUid },

                new Gender { Id = Guid.NewGuid(), Name = "Cis woman", Description = "A woman whose gender aligns with the sex they were assigned at birth.", ParentId = womanUid },
                new Gender { Id = Guid.NewGuid(), Name = "Intersex woman", Description = "A woman born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = womanUid },
                new Gender { Id = Guid.NewGuid(), Name = "Trans woman", Description = "A woman whose gender is different from her sex assigned at birth.", ParentId = womanUid },
                new Gender { Id = Guid.NewGuid(), Name = "Transfeminine", Description = "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", ParentId = womanUid },

                new Gender { Id = Guid.NewGuid(), Name = "Agender", Description = "A person who does not have a gender.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Bigender", Description = "A person who has two or more genders (can be simultaneously or fluid between them).", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Gender fluid", Description = "A person who does not have a single fixed gender.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Gender questioning", Description = "A person who is questioning their current gender and/or exploring other genders and expressions.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Genderqueer", Description = "A person who does not identify or express their gender within the gender binary.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Intersex", Description = "An umbrella term that refers to people born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Non-binary", Description = "A person whose gender is beyond the exclusive categories of man and woman.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Pangender", Description = "A person who experiences multiple genders either simultaneously or over time.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Trans person", Description = "A person who is transgender and their gender is different from the sex assigned to them at birth.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Transfeminine", Description = "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Transmasculine", Description = "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", ParentId = bbUid },
                new Gender { Id = Guid.NewGuid(), Name = "Two-Spirit", Description = "An umbrella term used across US Native American and Canadian First Nations communities to honour the sacred role that people who are not exclusively cisgender and/or heterosexual hold.", ParentId = bbUid }
            );
        }

        private static void seedAvailableDescriptors(ModelBuilder builder)
        {
            var jsonPath = Path.Combine("Data", "JsonSchema", "availableDescriptors.json");
            if (File.Exists(jsonPath))
            {
                var jsonString = File.ReadAllText(jsonPath);
                var availableDescriptorRoot = JsonSerializer.Deserialize<AvailableDescriptorRoot>(jsonString);
                var availableDescriptors = availableDescriptorRoot?.AvailableDescriptors;

                foreach (var descriptor in availableDescriptors!)
                {
                    builder.Entity<AvailableDescriptor>().HasData(descriptor);
                }
            }
        }
    }
}