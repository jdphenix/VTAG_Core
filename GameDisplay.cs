using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTAG_Attempt_2
{
    public static class GameDisplay
    {

        private static int GlobalPadding;
        private static string paddingAsString = "";


        public static void InitializeDisplay(int InitialWidth, int InitialHeight)
        {

            Console.WindowWidth = InitialWidth;
            Console.WindowHeight = InitialHeight;

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }



        public static void DrawMainMenu(MainMenuINI menu)
        {

            if(menu != null)
            {
                
                Console.Clear();

                Console.ForegroundColor = menu.MainTitle.Color;
                GetPadding(menu.MainTitle.Name);
                Console.SetCursorPosition(GlobalPadding, 0);
                Console.WriteLine(menu.MainTitle.Name);

                Console.ForegroundColor = menu.Subtitle.Color;
                GetPadding(menu.Subtitle.Name);
                Console.SetCursorPosition(GlobalPadding, 1);
                Console.WriteLine(menu.Subtitle.Name);

                Console.ForegroundColor = menu.Version.Color;
                GetPadding(menu.Version.Name);
                Console.SetCursorPosition(GlobalPadding, 2);
                Console.WriteLine(menu.Version.Name);


                Console.ResetColor();

            }

        }

        public static void DrawMainUI() { }


        public static MainMenuINI ParseMainMenu(string path)
        {
            MainMenuINI menu = new MainMenuINI();
            if (File.Exists(path))
            {

                string[] file = File.ReadAllLines(path);
                string[] parsedLines = new string[file.Length];
                
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i].StartsWith("##"))
                        continue;                    

                    string[] split = file[i].Split('=');

                    if (split[0].Equals("Padding"))
                        paddingAsString = split[1];


                    if (split.Length > 1)
                        parsedLines[i] = split[1];
                    else
                        parsedLines[i] = "";
                   
                }
                string[] splitName  = parsedLines[1].Split('|');
                string[] splitSub   = parsedLines[2].Split('|');
                string[] splitVer   = parsedLines[3].Split('|');

                menu.MainTitle.Name = splitName[0];
                menu.MainTitle.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor),splitName[1], true);
                

                menu.Subtitle.Name = splitSub[0];
                menu.Subtitle.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitSub[1], true);
                

                menu.Version.Name = splitVer[0];
                menu.Version.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitVer[1], true);

            }
            return menu;
        }

        internal static void GetPadding(string textToBeDisplayed)
        {
            switch (paddingAsString)
            {
                case "center":
                    GlobalPadding = Console.BufferWidth / 2 - textToBeDisplayed.Length / 2;
                        break;
                case "left":
                    GlobalPadding = 0;
                    break;
                case "right":
                    GlobalPadding = Console.BufferWidth - textToBeDisplayed.Length;
                    break;
            }
        }
    }
}
