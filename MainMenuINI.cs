using System;
using System.Collections.Generic;
using System.Drawing;

namespace VTAG_Attempt_2
{

    /*  Main Menu Format:
     * 
     * Main Title
     *      String, Color*, Alignment
     * Subtitle*
     *      String*, Color*, Alignment*
     * 
     * Version
     *      String
     * 
     * NewGame
     *      String
     * LoadGame
     *      String
     * Options
     *      String, Method**
     * Exit
     *      String
     * Credits*
     *      String
     * MOTD
     *      String
     * 
     */


    public class MainMenuINI
    {
        public Title MainTitle { get; set; }
        public Title Subtitle { get; set; }
        public Title Version { get; set; }
        public int   Padding { get; set; }

        public MainMenuINI()
        {
            MainTitle   = new Title();
            Subtitle    = new Title();
            Version     = new Title();
        }

    }

    public class Title
    {
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        
    }
}
