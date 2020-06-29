using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    [Serializable]
    class StartMenuDrawer : IMenuDrawer
    {
        static int index = 0;
        public readonly List<string> StyleMenu = new List<string>()
        {
            "Dark",
            "Light"
        };
        public readonly List<string> ResolutionMenu = new List<string>()
            {
                "Small",
                "Wide"
            };
        public readonly List<string> StartMenu = new List<string>()
            {
                "New Game",
                "Continue",
                "Exit",
            };
        public static readonly List<string> LabMenu = new List<string>()
        {
            "Become COOLLER",
            "Stats",
            "Change Hero",
            "Map",
            "World",
            "Quests",
            "Save",
            "Exit",
        };
        public readonly List<string> CoolHeroMenu = new List<string>()
        {
            "Choose boost",
            "Wolf",
            "Super Wolf",
            "Doser",
            "DISCO"
        };
        public readonly List<string> HeroMenu = new List<string>()
        {
            "PZshnik",
            "Lvasuk" ,
            "Animeshnik",
            "DeadInside"
        };

        public string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (i == index)
                {
                    ConsoleColor backgroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = backgroundColor;

                    Console.WriteLine(items[i]);

                    backgroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = backgroundColor;
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            switch (ckey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index == items.Count - 1)
                    {

                    }
                    else
                    {
                        ++index;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index <= 0)
                    {
                    }
                    else
                    {
                        --index;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    int foo = index;
                    index = 0;
                    return items[foo];
                case ConsoleKey.Escape:
                    return "back";
                default:

                    return "";

            }

            Console.Clear();
            return "";

        }
    }
}
