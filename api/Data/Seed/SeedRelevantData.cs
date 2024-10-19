using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Text.Json;

namespace api.Data
{
    public static class SeedRelevantData
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
                new RoomContent{Id = 1, Title = "Meet & Greet", Description = "Give us the scoop on the person behind the screen!", Duration = 1 * 60, Order = 1},
                new RoomContent{Id = 2, Title = "Hobby Showcase & Fun Fact Extravaganza", Description = "Share your passions and two quirky facts about yourself!", Duration = 2 * 60, Order = 2},
                new RoomContent{Id = 3, Title = "Random Question Roulette", Description = "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", Duration = 5 * 60, Order = 3},
                new RoomContent{Id = 4, Title = "Spotlight Q&A", Description = "Get ready to field questions from your adoring audience!", Duration = 5 * 60, Order = 4},
                new RoomContent{Id = 5, Title = "The Final Rose", Description = "Pop your best question to the remaining contenders, and whoever nails it gets the match!", Duration = 60, Order = 5}
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
            var sexualCategory = new QuestionCategory { Id = 1, Name = "Sexual" };
            var funnyCategory = new QuestionCategory { Id = 2, Name = "Funny" };
            var flirtyCategory = new QuestionCategory { Id = 3, Name = "Flirty" };
            var edgyCategory = new QuestionCategory { Id = 4, Name = "Edgy" };
            var connectionBuildingCategory = new QuestionCategory { Id = 5, Name = "Connection-building" };
            var dilemmaCategory = new QuestionCategory { Id = 6, Name = "Dilemma" };

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
                new SystemQuestion { Id = 1, Name = "What physical act gives you the most pleasure?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 2, Name = "Do you prefer firm or light touches?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 3, Name = "Do guy-on-guy videos turn you on more than guy-on-girl?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 4, Name = "Do you think it’s okay if a guy wants to be submissive in the bedroom?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 5, Name = "Would you rather receive or give oral?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 6, Name = "Do you prefer to make out with the lights on or off?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 7, Name = "Would you rather end a good first date with a passionate kiss or sex?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 8, Name = "Are you more dominant or submissive in bed?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 9, Name = "What do you fantasize about when you touch yourself?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 10, Name = "Do you like to roleplay?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 11, Name = "Have you ever had sex with someone you just met?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 12, Name = "What’s the dirtiest thought you’ve ever had about a stranger?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 13, Name = "What does your ideal one-night stand look like?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 14, Name = "If a cute couple asked you to do a threesome, would you say yes?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 15, Name = "What are your thoughts on toys?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 16, Name = "What’s the dirtiest thing someone said to you during sex?", CategoryId = sexualCategory.Id },
                new SystemQuestion { Id = 17, Name = "Where do you like to be touched most?", CategoryId = sexualCategory.Id },

                // Funny
                new SystemQuestion { Id = 18, Name = "What meal or snack will you never refuse?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 19, Name = "Zombies are overrunning the world. How do you defend yourself?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 20, Name = "What’s the weirdest thing you carry in your purse?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 21, Name = "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 22, Name = "What was the last time you went skinny dipping?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 23, Name = "Would you date someone who’s cute but mega dumb?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 24, Name = "What’s the last time you did something scary?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 25, Name = "You have to assassinate someone who really deserves it. How do you do it?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 26, Name = "If your friends and family hear that you were arrested, what would they think you did?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 27, Name = "You and all your friends have to enter a mixed martial arts tournament. Do you win?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 28, Name = "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 29, Name = "You find out your best friend is a lesbian and she’s in love with you. How do you react?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 30, Name = "Do you prefer the smell of freshly cut grass or freshly baked bread?", CategoryId = funnyCategory.Id },
                new SystemQuestion { Id = 31, Name = "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", CategoryId = funnyCategory.Id },

                // Flirty
                new SystemQuestion { Id = 32, Name = "What’s your favorite way to be seduced by a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 33, Name = "What do you miss most about being single? (She has to pick something.)", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 34, Name = "What’s the best romantic surprise you’ve ever had?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 35, Name = "What do you find the most attractive in a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 36, Name = "What does good sex mean to you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 37, Name = "What are your biggest turn-offs?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 38, Name = "What do you think is the most important thing a woman can give to a man?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 39, Name = "What makes you feel sexy?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 40, Name = "What’s the hottest thing a guy can do for you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 41, Name = "Can you surrender to love or is it something that scares you?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 42, Name = "Do you prefer cuddling or kissing?", CategoryId = flirtyCategory.Id },
                new SystemQuestion { Id = 43, Name = "What do you wear when you go to sleep?", CategoryId = flirtyCategory.Id },

                // Edgy
                new SystemQuestion { Id = 44, Name = "Would you rather have a cat with a human face or a dog with human hands?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 45, Name = "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 46, Name = "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 47, Name = "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 48, Name = "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 49, Name = "Would you rather speak every language fluently or play every instrument perfectly?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 50, Name = "Would you rather Win $50,000 or let your best friend win $500,000?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 51, Name = "Would you rather be stung by a thousand bees or stomp a kitten?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 52, Name = "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", CategoryId = edgyCategory.Id },
                new SystemQuestion { Id = 53, Name = "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", CategoryId = edgyCategory.Id },

                // Connection-building
                new SystemQuestion { Id = 54, Name = "Name three things that you can do to get out of a funk.", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 55, Name = "What’s a recent book you read or movie you saw that taught you something?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 56, Name = "Would you rather travel to the past or the future?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 57, Name = "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 58, Name = "If you could make one decision to change the world, what would you do?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 59, Name = "What’s the first thing you do when you get back home from work?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 60, Name = "If you could ask your pet 3 questions, what would they be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 70, Name = "What’s something you’d like to be remembered for?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 71, Name = "Is there a way you could fall head over heels for a man? What would that look like?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 72, Name = "What’s the most romantic thing you’ve ever done for someone?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 73, Name = "If you were the mayor of your city, what rule would you instantly enforce?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 74, Name = "What’s your favorite and least favorite household chore?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 75, Name = "What’s one responsibility of yours that you’d prefer to delegate to a professional?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 76, Name = "What’s something you’ve always wanted to do, but haven’t?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 77, Name = "Would you continue working if you were rich and didn’t need to?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 78, Name = "What does your ideal night look like? Do you go out or are you at home with friends?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 79, Name = "If you could change one thing about the way you were raised, what would that be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 80, Name = "What’s something that gives your life meaning?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 90, Name = "What dating advice would you give your younger self?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 91, Name = "What song would you want to play on your wedding day?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 92, Name = "What would you like to get for your birthday?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 93, Name = "If you could only put on one piece of makeup, what would it be?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 94, Name = "What’s the one compliment you get the most?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 95, Name = "Where do you feel the most at home?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 96, Name = "What do you wish you cared less about?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 97, Name = "What do your friends and family call you?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 98, Name = "Where do you go if you want to escape?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 99, Name = "What’s something you swear by?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 100, Name = "What’s the most important thing your life is missing?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 101, Name = "What do you wish more people knew about you?", CategoryId = connectionBuildingCategory.Id },
                new SystemQuestion { Id = 102, Name = "How long ago did you tell someone you loved them?", CategoryId = connectionBuildingCategory.Id },

                // Dilemma
                new SystemQuestion { Id = 103, Name = "Flight or invisibility?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 104, Name = "Peanut butter or Nutella?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 105, Name = "Quit coffee or never have snacks during films and series?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 106, Name = "Bath or shower?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 107, Name = "Love or money?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 108, Name = "Burger or pizza?", CategoryId = dilemmaCategory.Id },
                new SystemQuestion { Id = 109, Name = "Dine-in or delivery?", CategoryId = dilemmaCategory.Id }
            });
        }

        private static void seedGenders(ModelBuilder builder)
        {
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Man", ParentId = null },
                new Gender { Id = 2, Name = "Woman", ParentId = null },
                new Gender { Id = 3, Name = "Beyond binary", ParentId = null },

                new Gender { Id = 4, Name = "Cis man", Description = "A man whose gender aligns with the sex they were assigned at birth.", ParentId = 1 },
                new Gender { Id = 5, Name = "Intersex man", Description = "A man born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = 1 },
                new Gender { Id = 6, Name = "Trans man", Description = "A man whose gender is different from his sex assigned at birth.", ParentId = 1 },
                new Gender { Id = 7, Name = "Transmasculine", Description = "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", ParentId = 1 },

                new Gender { Id = 8, Name = "Cis woman", Description = "A woman whose gender aligns with the sex they were assigned at birth.", ParentId = 2 },
                new Gender { Id = 9, Name = "Intersex woman", Description = "A woman born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = 2 },
                new Gender { Id = 10, Name = "Trans woman", Description = "A woman whose gender is different from her sex assigned at birth.", ParentId = 2 },
                new Gender { Id = 11, Name = "Transfeminine", Description = "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", ParentId = 2 },

                new Gender { Id = 12, Name = "Agender", Description = "A person who does not have a gender.", ParentId = 3 },
                new Gender { Id = 13, Name = "Bigender", Description = "A person who has two or more genders (can be simultaneously or fluid between them).", ParentId = 3 },
                new Gender { Id = 14, Name = "Gender fluid", Description = "A person who does not have a single fixed gender.", ParentId = 3 },
                new Gender { Id = 15, Name = "Gender questioning", Description = "A person who is questioning their current gender and/or exploring other genders and expressions.", ParentId = 3 },
                new Gender { Id = 16, Name = "Genderqueer", Description = "A person who does not identify or express their gender within the gender binary.", ParentId = 3 },
                new Gender { Id = 17, Name = "Intersex", Description = "An umbrella term that refers to people born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", ParentId = 3 },
                new Gender { Id = 18, Name = "Non-binary", Description = "A person whose gender is beyond the exclusive categories of man and woman.", ParentId = 3 },
                new Gender { Id = 19, Name = "Pangender", Description = "A person who experiences multiple genders either simultaneously or over time.", ParentId = 3 },
                new Gender { Id = 20, Name = "Trans person", Description = "A person who is transgender and their gender is different from the sex assigned to them at birth.", ParentId = 3 },
                new Gender { Id = 21, Name = "Transfeminine", Description = "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", ParentId = 3 },
                new Gender { Id = 22, Name = "Transmasculine", Description = "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", ParentId = 3 },
                new Gender { Id = 23, Name = "Two-Spirit", Description = "An umbrella term used across US Native American and Canadian First Nations communities to honour the sacred role that people who are not exclusively cisgender and/or heterosexual hold.", ParentId = 3 }
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