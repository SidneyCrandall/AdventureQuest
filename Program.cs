using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance for the adventure to have a color for their robe
            Robe AdventureRobe = new Robe();
            {
                AdventureRobe.RobeLength = 60;
                AdventureRobe.Colors = new List<string>()
                {
                    "purple,", " ", "green,"," ", "and blue"
                };
            }

            // A shiney hat to protect the adventurer on his way 
            Hat AdventurerHat = new Hat();
            {
                AdventurerHat.ShininessLevel = 13;
            }

            // Every quest must have a prize 
            Prize AdventurerPrize = new Prize("All the donuts in the World");

            // Askk the challenger if he would like ot replay the quest again 
            bool Replay = true;
            while (Replay)
            {
                Console.WriteLine("What is your name?");
                string AdventurerName = Console.ReadLine();

                // Create a few challenges for our Adventurer's quest
                // The "Challenge" Constructor takes three arguments
                //   the text of the challenge
                //   a correct answer
                //   a number of awesome points to gain or lose depending on the success of the challenge
                //  Creating a dynamic list that will change challenges whenever the program is ran. 
                List<Challenge> holyGrail = new List<Challenge>() {
                new Challenge("2 + 2?", 4, 10),

                new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25),

                new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50),

                new Challenge("What number am I thinking of?", new Random().Next() % 10, 25),

                new Challenge(
                    @"Who's your favorite Beatle?
                    1) John
                    2) Paul
                    3) George
                    4) Ringo",
                            4, 20
                    ),

                new Challenge(
                    @"Who is my favorite dog?
                    1) Digby
                    2) Fenrir
                    3) Miko",
                            3, 10
                ),

                new Challenge(
                    @"Which is my favorite anime to watch?
                    1) My Hero Academia
                    2) Attack on Titan
                    3) Cowboy Bebop
                    4) Carole & Tuesday
                    5) Tokyo Ghoul",
                            2, 10
                ),

                new Challenge(
                    @"Who is the best Golden Girl?
                    1) Rose
                    2) Dorothy
                    3) Sophia
                    4) Blanche",
                            2, 10
                ),

                new Challenge(
                    @"Whish Doctor is the best?
                    1) 10th
                    2) 9th
                    3) 4th
                    4) 6th
                    5) It's not that simple one must weight many factors in determing this answer...",
                            5, 50
                ),

                new Challenge(
                    @"Can god even defeat Tom Nook?
                    1) Yes
                    2) No",
                            2, 100
                ),
            };

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                Adventurer theAdventurer = new Adventurer(AdventurerName, AdventureRobe, AdventurerHat);

                // Line that will give the description of what the adventurer is wearing. This is from Adventurer.cs
                Console.WriteLine(theAdventurer.GetDescription());

                // If a layer redoes the quest 
                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = Challenge.GetRandomQuestions(holyGrail);

                /* Old Code that would have asked all the questions to the Adventurer
                {
                    twoPlusTwo,
                    theAnswer,
                    whatSecond,
                    guessRandom,
                    favoriteBeatle,
                    favoriteAnime,
                    favoriteDog,
                    bestGoldenGirl,
                    bestDoctor,
                    tomNook
                };*/

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in challenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                // Show the adventurers prize before the Replay 
                AdventurerPrize.ShowPrize(theAdventurer);

                // Prompt for replay to be triggered
                Console.WriteLine();
                Console.Write($"{AdventurerName}, would you like you increase your Awesomeness, and try again? (Y/N):  ");

                string Reply = Console.ReadLine().ToLower();

                if (Reply == "y")
                {
                    Replay = true;
                    Console.WriteLine("Your quest starts... again...");
                }
                else if (Reply == "n")
                {
                    Replay = false;
                    Console.WriteLine("Very well, I will see you another time.");
                }
            }
        }
    }
}