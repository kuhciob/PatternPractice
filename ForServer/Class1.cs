using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForServer
{
    [Serializable]
    public abstract class Command
    {
        protected Receiver receiver;
        public Receiver Receiver { get { return receiver; } }
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void SetReceiver(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    [Serializable]
    public class Receiver
    {
        IUserInterface GameUI;
        Player player;
        List<string> CurrentMenu;
        public Receiver(IUserInterface ui, Player hero, List<string> menu)
        {
            GameUI = ui;
            player = hero;
            CurrentMenu = menu;
        }
        public void Save()
        {
            UIMemento.Originator UIOrig = new UIMemento.Originator();
            UIOrig.SetState(GameUI);
            UIMemento.Caretaker.SaveState(UIOrig);

            PlayerMemento.Originator PlayerOrig = new PlayerMemento.Originator();
            PlayerOrig.SetState(player);
            PlayerMemento.Caretaker.SaveState(PlayerOrig);
        }
        public void Load()
        {
            UIMemento.Originator UIOrig = new UIMemento.Originator();
            UIMemento.Caretaker.RestoreState(UIOrig);
            GameUI = UIOrig.GetState();

            PlayerMemento.Originator PlayerOrig = new PlayerMemento.Originator();
            PlayerMemento.Caretaker.RestoreState(PlayerOrig);
            player = PlayerOrig.GetState();

            GameUI.SetResolution();
            GameUI.SetStyle();
            CurrentMenu = StartMenuDrawer.LabMenu;
        }
    }
    [Serializable]
    public abstract class IUserInterface
    {

        protected static readonly double DisplayHeight = SystemParameters.PrimaryScreenHeight;
        protected static readonly double DisplayWidth = SystemParameters.PrimaryScreenWidth;

        public abstract void SetStyle();
        public abstract void SetResolution();

    }
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
    [Serializable]
    public class SaveManager
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        public void Execute()
        {
            command.Execute();
        }
    }
}
