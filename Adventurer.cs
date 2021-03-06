namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; }

        // This is an "immutable" property. It only will have a 'get'. 
        // The only place the Robe can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public Robe ColorfulRobe { get; }

        // This is an "immutable" property. It only will have a 'get'. 
        // The only place the Hat can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public Hat ShineyHat { get; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int Awesomeness { get; set; }

        // This is a mutable property it has a "get" and a "set"
        // This will keep tally of how well the adventurer has done if they would like to repeat challenges
        public int SuccessRate { get; set; }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe AdventurerRobe, Hat AdventurerHat)
        {
            Name = name;
            Awesomeness = 50;
            ColorfulRobe = AdventurerRobe;
            ShineyHat = AdventurerHat; 
            SuccessRate = 0;
        }

        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }

        // GetDescription of the adventurer in a string .method that will assign a color to the robe of the adventurer
        public string GetDescription()
        {
            string robeColors = "";

            foreach ( string colors in ColorfulRobe.Colors)
            {
                robeColors += $"{colors}";
            }
            return $"{Name}, the adventurer, ventured into the unknown in their {robeColors} patchwork robe that was {ColorfulRobe.RobeLength} inches in length, and their {ShineyHat.ShininessDescription()} hat. They jumped as the Troll appeared to challenge them...";
        }
    }
}