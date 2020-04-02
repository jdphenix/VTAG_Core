using System;
using System.Drawing;


namespace VTAG_Attempt_2
{


    /*
    TO-DO:
    DISPLAY:
        - Main Menu processing
            - Splash?
            - Menu options
        - Gameplay HUD
            - HUD config
            - Display areas config
    GAME MODELS
        - Game state
        - Creature / Player
        - Inventory / Item system
    GAME MAP:
        - BMP Processing (Dev Tool)
        - Game Data Storage
        - Points of interest / Story or Event triggering
    */

    public class Program_Start
    {        
        public static void Main(string[] args)
        {
            GameDisplay.InitializeDisplay();
            GameDisplay.DrawMainMenu();
            Console.ReadKey();

        }



    }
}

