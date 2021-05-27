using System;
// used to call all the code for the program run.
namespace Quest
{
    public class Hat 
    {
        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int ShininessLevel { get; set; }
        public string ShininessDescription()
        // Description will be crried into the adventurer file to give further decription to the adventurer.
        // if/else to generate how the hat shal appear
        {
            if (ShininessLevel <= 2)
            {
                return "dull";
            }
            else if (ShininessLevel > 2 && ShininessLevel <= 5)
            {
                return "noticeable";
            }
            else if (ShininessLevel > 5 && ShininessLevel <= 9)
            {
                return "bright";
            }
            else 
            {
                return "blinding";
            }
        }
    }
}