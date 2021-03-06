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
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);

                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);

                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                //int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", new Random().Next() % 10, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
                    1) John
                    2) Paul
                    3) George
                    4) Ringo",
                            4, 20
                );

                Challenge favoriteDog = new Challenge(
                    @"Who is my favorite dog?
                    1) Digby
                    2) Fenrir
                    3) Miko",
                            3, 10
                );

                Challenge favoriteAnime = new Challenge(
                    @"Which is my favorite anime to watch?
                    1) My Hero Academia
                    2) Attack on Titan
                    3) Cowboy Bebop
                    4) Carole & Tuesday
                    5) Tokyo Ghoul",
                            2, 10
                );

                Challenge bestGoldenGirl = new Challenge(
                    @"Who is the best Golden Girl?
                    1) Rose
                    2) Dorothy
                    3) Sophia
                    4) Blanche",
                            2, 10
                );

                Challenge bestDoctor = new Challenge(
                    @"Whish Doctor is the best?
                    1) 10th
                    2) 9th
                    3) 4th
                    4) 6th
                    5) It's not that simple one must weight many factors in determing this answer...",
                            5, 50
                );

                Challenge tomNook = new Challenge(
                    @"Can god even defeat Tom Nook?
                    1) Yes
                    2) No",
                            2, 75
                );
        

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                Adventurer theAdventurer = new Adventurer(AdventurerName, AdventureRobe, AdventurerHat);

                // Every quest must have a prize 
                Prize AdventurerPrize = new Prize("All the donuts in the World");

                // Line that will give the description of what the adventurer is wearing. This is from Adventurer.cs
                Console.WriteLine(theAdventurer.GetDescription());

                // If a layer redoes the quest 
                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
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
                };

                // Loop through all the challenges and subject the Adventurer to them
                // also randomize them with no repeats
                Random r = new Random();
                List<int> indexes = new List<int> {};
                while (indexes.Count < 5)
                {
                    int candidate = r.Next(0, challenges.Count);
                    if (!indexes.Contains(candidate)) {
                        indexes.Add(candidate);
                    }
                }

                for (int i = 0; i < indexes.Count; i++)
                {
                    int index = indexes[i];
                    challenges[index].RunChallenge(theAdventurer);
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

                // Adding points to the adventurer's score if they choose to play again. 
                // If the user chooses to repeat the quest, multiply this number by 10 and add it do the initial Awesomeness (50, found in Challenge.cs) of the adventurer on their next quest.
                theAdventurer.Awesomeness = 50 + theAdventurer.SuccessRate * 10;

                // Prompt for replay to be triggered
                Console.WriteLine();
                Console.Write($"{AdventurerName}, you have completed {theAdventurer.SuccessRate} challenges!");
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