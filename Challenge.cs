using System;
using System.Collections.Generic;

namespace Quest
{
    // An instance of the Challenge class is an occurrence of a single challenge
    public class Challenge
    {
        // These private fields hold the "state" of an individual challenge object.
        // The values stored in these fields are not accessible outside the class,
        //  but can be used by methods or properties within the class
        private string _text;
        private int _correctAnswer;
        private int _awesomenessChange;


        // A constructor for the Challenge
        // We can tell it's a constructor because it has the same name as the class 
        //   and it doesn't specify a return type
        // Note the constructor parameters and what is done with them
        public Challenge(string text, int correctAnswer, int awesomenessChange)
        {
            _text = text;
            _correctAnswer = correctAnswer;
            _awesomenessChange = awesomenessChange;
        }

        // This method will take an Adventurer object and make that Adventurer perform the challenge
        public void RunChallenge(Adventurer adventurer)
        {
            Console.Write($"{_text}: ");
            string answer = Console.ReadLine();

            int numAnswer;
            bool isNumber = int.TryParse(answer, out numAnswer);

            Console.WriteLine();
            if (isNumber && numAnswer == _correctAnswer)
            {
                Console.WriteLine("Well Done!");

                // Note how we access an Adventurer object's property
                adventurer.Awesomeness += _awesomenessChange;
            }
            else
            {
                Console.WriteLine("You have failed the challenge, there will be consequences.");
                adventurer.Awesomeness -= _awesomenessChange;
            }

            // Note how we call an Adventurer object's method
            Console.WriteLine(adventurer.GetAdventurerStatus());
            Console.WriteLine();
        }

        // NOw the program needs to find a way to look at the objects on the list and iterate through them.
        // It will then randomly generate at least five questions that aren't repeated.
        public static List<Challenge> GetRandomQuestions(List<Challenge> list)
        {
            Random r = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 5; i++)
            {
                // do/while loop will execute code block once, before checking if condition is true
                do
                {
                    // Count will look at how many ?'s are in the list
                    number = r.Next(0, list.Count);
                }
                // seeing how many questions are in the list
                while (listNumbers.Contains(number));
                //adding a new question to the new list for the program
                listNumbers.Add(number);
            }

            // This will be read along with the do/while to iterate the List and return the random question to be asked by the challenger
            // essential making a new list of question that will run in the program
            List<Challenge> challengeList = new List<Challenge>();
            foreach (int index in listNumbers)
            {
                // Add an iterated question to the new challenge
                challengeList.Add(list[index]);
            }
            // return the new list that has only 5 ?'s that will be called again in PRogram.cs and executed
            return challengeList;
        }
    }
}