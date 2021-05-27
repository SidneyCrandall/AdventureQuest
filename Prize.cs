using System;

namespace Quest
{
    public class Prize
    {
        /* These private fields hold the "state" of a prize object.
            The values stored in these fields are not accessible outside the class,
            but can be used by methods or properties within the class*/
        private string _text;

        /* A constructor for the Prize
         We can tell it's a constructor because it has the same name as the class 
         and it doesn't specify a return type
         Note the constructor parameters and what is done with them*/
        public Prize(string text)
        {
            _text = text;
        }

        // This method will take an Adventurer object and givee that Adventurer a prize for the challenge
        public void ShowPrize(Adventurer Person)
        {
            if (Person.Awesomeness > 0)
            {
                for (int i = 0; i < Person.Awesomeness - 1; i++)
                {
                    Console.WriteLine(_text);
                }
            }
            else
            {
                Console.WriteLine("You have always been doomed ... ");
            }

        }
    }
}