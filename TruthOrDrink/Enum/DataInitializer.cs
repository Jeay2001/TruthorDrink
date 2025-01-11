using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.Enum
{
    public static class DataInitializer
    {
        public static List<Category> InitializeCategories()
        {
            var categories = new List<Category>
                {
                    new Category
                    {
                        Name = CategoryEnum.Party,
                        Difficulty = DifficultyEnum.Easy,
                        Questions = InitializeQuestions(CategoryEnum.Party, DifficultyEnum.Easy)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Party,
                        Difficulty = DifficultyEnum.Medium,
                        Questions = InitializeQuestions(CategoryEnum.Party, DifficultyEnum.Medium)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Party,
                        Difficulty = DifficultyEnum.Hard,
                        Questions = InitializeQuestions(CategoryEnum.Party, DifficultyEnum.Hard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Party,
                        Difficulty = DifficultyEnum.VeryHard,
                        Questions = InitializeQuestions(CategoryEnum.Party, DifficultyEnum.VeryHard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Party,
                        Difficulty = DifficultyEnum.Extreme,
                        Questions = InitializeQuestions(CategoryEnum.Party, DifficultyEnum.Extreme)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Friends,
                        Difficulty = DifficultyEnum.Easy,
                        Questions = InitializeQuestions(CategoryEnum.Friends, DifficultyEnum.Easy)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Friends,
                        Difficulty = DifficultyEnum.Medium,
                        Questions = InitializeQuestions(CategoryEnum.Friends, DifficultyEnum.Medium)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Friends,
                        Difficulty = DifficultyEnum.Hard,
                        Questions = InitializeQuestions(CategoryEnum.Friends, DifficultyEnum.Hard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Friends,
                        Difficulty = DifficultyEnum.VeryHard,
                        Questions = InitializeQuestions(CategoryEnum.Friends, DifficultyEnum.VeryHard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Friends,
                        Difficulty = DifficultyEnum.Extreme,
                        Questions = InitializeQuestions(CategoryEnum.Friends, DifficultyEnum.Extreme)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Family,
                        Difficulty = DifficultyEnum.Easy,
                        Questions = InitializeQuestions(CategoryEnum.Family, DifficultyEnum.Easy)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Family,
                        Difficulty = DifficultyEnum.Medium,
                        Questions = InitializeQuestions(CategoryEnum.Family, DifficultyEnum.Medium)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Family,
                        Difficulty = DifficultyEnum.Hard,
                        Questions = InitializeQuestions(CategoryEnum.Family, DifficultyEnum.Hard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Family,
                        Difficulty = DifficultyEnum.VeryHard,
                        Questions = InitializeQuestions(CategoryEnum.Family, DifficultyEnum.VeryHard)
                    },
                    new Category
                    {
                        Name = CategoryEnum.Family,
                        Difficulty = DifficultyEnum.Extreme,
                        Questions = InitializeQuestions(CategoryEnum.Family, DifficultyEnum.Extreme)
                    }
                };

            return categories;
        }

        public static List<Question> InitializeQuestions(CategoryEnum category, DifficultyEnum difficulty)
        {
            var questions = new List<Question>();

            if (category == CategoryEnum.Party)
            {
                questions.AddRange(GetPartyQuestions(difficulty));
            }
            else if (category == CategoryEnum.Friends)
            {
                questions.AddRange(GetFriendsQuestions(difficulty));
            }
            else if (category == CategoryEnum.Family)
            {
                questions.AddRange(GetFamilyQuestions(difficulty));
            }

            return questions;
        }

        public static List<Question> GetPartyQuestions(DifficultyEnum difficulty)
        {
            var questions = new List<Question>();

            if (difficulty == DifficultyEnum.Easy)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever danced on a table?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Show us your best dance move.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever sung karaoke?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Sing a song chosen by the group.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever played a drinking game?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Take a sip of your drink.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been to a costume party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do an impression of your favorite character.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever stayed up all night partying?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Dance with no music for 1 minute.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Medium)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever kissed someone at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Take a shot of a drink chosen by the group.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever played spin the bottle?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Spin around 10 times and try to walk straight.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever danced with a stranger?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Dance with an imaginary partner.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever played truth or dare at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 10 jumping jacks.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been the last one to leave a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Pretend to be a DJ for 1 minute.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Hard)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever lied to get out of trouble at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a funny impression of someone in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been kicked out of a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Pretend to be a bouncer and check IDs.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever played a prank at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Tell a joke and make everyone laugh.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking into a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Act like a celebrity and give an acceptance speech.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to do something embarrassing at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do your best impression of a famous person.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.VeryHard)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in a fight at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 20 push-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking out of a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a cartwheel.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to do something dangerous?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Eat something spicy.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught lying at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a handstand for 10 seconds.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to kiss someone?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Kiss someone on the cheek.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Extreme)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever been arrested at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a backflip.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in a physical fight at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Eat a raw onion.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught doing something illegal at a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Drink a raw egg.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to do something illegal?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 50 push-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking into a party?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a dance for 2 minutes.", Type = "Dare", Difficulty = difficulty });
            }

            return questions;
        }

        public static List<Question> GetFriendsQuestions(DifficultyEnum difficulty)
        {
            var questions = new List<Question>();

            if (difficulty == DifficultyEnum.Easy)
            {
                questions.Add(new Question { QuestionText = "Truth: Who is your best friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Give a compliment to each person in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a sleepover with friends?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Share a funny story from a sleepover.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever made a friendship bracelet?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Make a funny face and hold it for 10 seconds.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a secret handshake with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Create a secret handshake with someone in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever shared a secret with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Whisper a secret to someone in the room.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Medium)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a crush on a friend's sibling?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Send a funny text to a friend not in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever borrowed something from a friend and never returned it?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Call a friend and sing them a song.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a fight with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Apologize to someone in the room for something.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever told a friend's secret?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Tell a funny joke to the group.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever made a prank call with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Make a prank call to someone you know.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Hard)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever betrayed a friend's trust?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Let someone draw on your face with a marker.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever lied to a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do an impression of a friend in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been jealous of a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Act like a famous person and let others guess who you are.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever spread a rumor about a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 10 push-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in a fight with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Let someone tickle you for 30 seconds.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.VeryHard)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in a fight with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 20 push-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught lying to a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a cartwheel.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to do something dangerous?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Eat something spicy.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking out with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a handstand for 10 seconds.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to kiss a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Kiss a friend on the cheek.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Extreme)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever been arrested with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a backflip.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in a physical fight with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Eat a raw onion.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught doing something illegal with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Drink a raw egg.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been dared to do something illegal with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 50 push-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking into a party with a friend?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do a dance for 2 minutes.", Type = "Dare", Difficulty = difficulty });
            }

            return questions;
        }

        public static List<Question> GetFamilyQuestions(DifficultyEnum difficulty)
        {
            var questions = new List<Question>();

            if (difficulty == DifficultyEnum.Easy)
            {
                questions.Add(new Question { QuestionText = "Truth: What is your favorite family tradition?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Hug everyone in the room.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a family game night?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Play a quick game of charades.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: What is your favorite family vacation?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Share a funny story from a family vacation.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a family pet?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Pretend to be a family pet for 1 minute.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: What is your favorite family meal?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Describe your favorite meal without saying its name.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Medium)
            {
                questions.Add(new Question { QuestionText = "Truth: Have you ever lied to your parents?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do an impression of a family member.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been grounded?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Act like a robot for 1 minute.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a family argument?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Tell a funny joke to the group.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking out?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 10 jumping jacks.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever had a family nickname?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Let someone give you a funny nickname.", Type = "Dare", Difficulty = difficulty });
            }
            else if (difficulty == DifficultyEnum.Hard)
            {
                questions.Add(new Question { QuestionText = "Truth: What is the biggest secret you have kept from your family?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Sing a song chosen by the group.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been in trouble at school?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Act like a teacher and give a lesson.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught lying?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Tell a funny story about yourself.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught doing something you shouldn't?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Do 10 sit-ups.", Type = "Dare", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Truth: Have you ever been caught sneaking food?", Type = "Truth", Difficulty = difficulty });
                questions.Add(new Question { QuestionText = "Dare: Pretend to be a chef and describe a dish.", Type = "Dare", Difficulty = difficulty });
            }

            return questions;
        }
    }
}
