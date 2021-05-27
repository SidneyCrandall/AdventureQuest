using System;

using System.Collections.Generic;

/* making "mutable properties" that will be used in the program.
 we dont need a new constructor just yet. We need to at least see and change the property later */
namespace Quest
{
    public class Robe
    {
        public List<string> Colors { get; set; }
        public int RobeLength { get; set; }
    }
}