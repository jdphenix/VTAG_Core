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
        public static string[] mainMenu;

        public static void InitializeDisplay()
        {
            GetMainMenu();
            ParseMainMenu(@".\UI\MainMenu.ini");
            if (mainMenu != null)
            {
                int widest = 0;
                int lines = mainMenu.Length;
                for (int i = 0; i < mainMenu.Length; i++)
                {
                    widest = mainMenu[i].Length > widest ? mainMenu[i].Length : widest;
                }
                Console.WindowWidth = widest + 1;
            }
            else
            {
                Console.WindowWidth = 100;
                Console.WindowHeight = 50;
            }

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }

        public static void GetMainMenu()
        {
            if (File.Exists(@".\UI\MainMenu.txt"))
            {
                mainMenu = File.ReadAllLines(@".\UI\MainMenu.txt");
            } 
            else if (File.Exists(@".\UI\Templates\MainMenu_Template.txt"))
            {
                mainMenu = File.ReadAllLines(@".\UI\Templates\MainMenu_Template.txt");
            }
            else
            {
                Console.WriteLine("This menu shouldn't be writing! If you see this, the menu file AND the template have gone missing or corrupt!");
                Console.ReadKey(true);
                System.Environment.Exit(-1);
            }
        }

        public static void DrawMainMenu()
        {

            if(mainMenu != null)
            {
                Console.Clear();
                for(int i = 0; i < mainMenu.Length; i++)
                {
                    Console.WriteLine(mainMenu[i]);
                }
            }

        }

        public static void DrawMainUI()
        {

        }


        public static MainMenuINI ParseMainMenu(string path)
        {
            MainMenuINI menu = new MainMenuINI();
            if (File.Exists(path))
            {
                
                string[] file = File.ReadAllLines(path);
                for(int i = 0; i < file.Length; i++)
                {
                    if (file[i].StartsWith("##"))
                    {
                        continue;
                    }
                    string[] initialSplit = file[i].Split('=');
                    var name = initialSplit[0];
                    var properties = initialSplit[1];
                    string[] splitProperties = properties.Split('|');
                    menu.MainTitle.Name = name == "MainTitle" ? name : "Unexpected token on line 2";
                    menu.MainTitle.Alignment = splitProperties[2];

                }
                
            }
            return menu;
        }



    }
}
