using GAME.ClientServer;
using GAME.GameClasses.CommandPattern;
using GAME.GameClasses.Composer;
using GAME.GameClasses.StatePattern;
using GAME.GameClasses.StatePattern.QuestState;
using GAME.GameClasses.UIFactory;
using GAME.Interfaces;
using GAME.Interfaces.UIFactory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    class GameFacade
    {
        public Player Hero { set { player = value; } get { return player; } }
        public Level Level { get { return currentlevel; } }
        public List<string> Menu { set { CurrentMenu = value; } get { return CurrentMenu; } }
        public IUserInterface UI { set { GameUI = value; } get { return GameUI; } }
        private IController controller;
        private ISaver Saver;
        private IuiFactory iuiFactory = null;

        private MenuHandler menuHandler=new MenuHandler();

        private IUserInterface GameUI = null;

        private IWorldComponent WorldHead;

        private GAME.GameClasses.PlayerMemento.Caretaker HeroSaver=new PlayerMemento.Caretaker();
        private GAME.GameClasses.UIMemento.Caretaker UISaver=new UIMemento.Caretaker();

        private Player player;
        
        private IMenuDrawer menuDrawer;
        private Level currentlevel;
        SoundPlayerSingletone OSTPlayer;
        private Map gameMap;
        private List<string> CurrentMenu=new List<string>();
        private QuestsManeger questsManeger=new QuestsManeger();
        KeyListener KListener;
        CommandPattern.Receiver MyRaceiver;
        public void StartGame()
        {
            ClientServer.MyServer.Run();
            //Process.Start("Z:\\!Ivasuk\\!SE\\PZ24\\MAPZ\\mapz\\Patterns\\GAME\\Server\\bin\\Debug\\Server.exe");
            SoundPlayerSingletone.GetPlayerIstanse().PlayByRelPath("\\Sound\\MenuOST.wav");
            CreateWorld();
            Console.CursorVisible = false;
            menuDrawer = new StartMenuDrawer();
            CurrentMenu = ((StartMenuDrawer)menuDrawer).StartMenu;
            ReservHandlers();
            questsManeger.CreateStartQuests();

            MyRaceiver = new CommandPattern.Receiver(this.GameUI,this.player,this.CurrentMenu);        
            KListener = new KeyListener();
            KListener.SetReceiver(MyRaceiver);
            KListener.StartListen();

            while (true)
            {
                string selectedMenuItem = menuDrawer.DrawMenu(CurrentMenu).ToLower();
                if( !menuHandler.HandleItem(selectedMenuItem))
                    Console.Clear();
            }

            
        }
        public event EventHandler ThresholdReached;
        
        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }
       
        private void ReservHandlers()
        {
            menuHandler.AddDelegate("change hero", () =>
            {
                ChooseHero();
                CurrentMenu = StartMenuDrawer.LabMenu;
            });
            menuHandler.AddDelegate("stats", () =>
            {
                
                 player.ShowPlayer();
                CurrentMenu = StartMenuDrawer.LabMenu;
            });
            menuHandler.AddDelegate("disco", () =>
            {
                player = new Decorator.DiscoDecorator(player);
                CurrentMenu = StartMenuDrawer.LabMenu;
                player.ShowPlayer();
            });
            menuHandler.AddDelegate("doser", () =>
            {
                player = new Decorator.DoserDecorator(player);
                CurrentMenu = StartMenuDrawer.LabMenu;
                player.ShowPlayer();
            });
            menuHandler.AddDelegate("super wolf", () =>
            {
                player = new Decorator.SuperWolfPlayer(player);
                CurrentMenu = StartMenuDrawer.LabMenu; 
                player.ShowPlayer();
            });
            menuHandler.AddDelegate("wolf", () =>
            {
                player = new Decorator.WolfPlayer(player);
                CurrentMenu = StartMenuDrawer.LabMenu;
                player.ShowPlayer();
            });
            menuHandler.AddDelegate("become cooller", () =>
            {
                CurrentMenu = ((StartMenuDrawer)menuDrawer).CoolHeroMenu;
            });
            menuHandler.AddDelegate("world", () =>
            {
                Console.WriteLine(WorldHead.GetInfo());
                CurrentMenu = StartMenuDrawer.LabMenu;
            });
            menuHandler.AddDelegate("map", () =>
            {
                CallStartMap();
                CurrentMenu = StartMenuDrawer.LabMenu;
            });
            menuHandler.AddDelegate("small", () =>
            {
                Console.Clear();
                GameUI = iuiFactory.BuildSmallUI();
                GameUI.SetResolution();
                GameUI.SetStyle();
                ChooseHero();
                CurrentMenu = StartMenuDrawer.LabMenu;

            });
            menuHandler.AddDelegate("wide", () =>
            {
                Console.Clear();
                GameUI = iuiFactory.BuildWideUI();
                GameUI.SetResolution();
                GameUI.SetStyle();
                ChooseHero();
                CurrentMenu = StartMenuDrawer.LabMenu;
            });
            menuHandler.AddDelegate("light", () =>
            {
                Console.Clear();
                iuiFactory = new LightUIFactory();
                CurrentMenu = ((StartMenuDrawer)menuDrawer).ResolutionMenu;
            });
            menuHandler.AddDelegate("dark", () =>
            {
                Console.Clear();
                iuiFactory = new DarkUIFactory();
                CurrentMenu = ((StartMenuDrawer)menuDrawer).ResolutionMenu;
            });
            menuHandler.AddDelegate("exit", () => { System.Environment.Exit(1); });
            menuHandler.AddDelegate("new game", () =>
            {
                Console.Clear();
                CurrentMenu = ((StartMenuDrawer)menuDrawer).StyleMenu;
            });
            menuHandler.AddDelegate("continue", () =>
            {
                Console.Clear();
                UIMemento.Originator UIOrig = new UIMemento.Originator();
                UIMemento.Caretaker.RestoreState(UIOrig);
                GameUI = UIOrig.GetState();

                PlayerMemento.Originator PlayerOrig = new PlayerMemento.Originator();
                PlayerMemento.Caretaker.RestoreState(PlayerOrig);
                player = PlayerOrig.GetState();

                GameUI.SetResolution();
                GameUI.SetStyle();
                CurrentMenu = StartMenuDrawer.LabMenu;
                //Command order = new LoadCommand(receiver);
                //send to invoker
            });
            menuHandler.AddDelegate("save", () =>
            {
                Console.Clear();

                UIMemento.Originator UIOrig = new UIMemento.Originator();
                UIOrig.SetState(GameUI);
                UIMemento.Caretaker.SaveState(UIOrig);

                PlayerMemento.Originator PlayerOrig = new PlayerMemento.Originator();
                PlayerOrig.SetState(player);
                PlayerMemento.Caretaker.SaveState(PlayerOrig);
                CurrentMenu = StartMenuDrawer.LabMenu;

                //Command order = new SaveCommand(receiver);
                //send to invoker
            });
            menuHandler.AddDelegate("quests", () =>
            {
                Console.Clear();
                questsManeger.ShowQuests();
                
                //CurrentMenu = ((StartMenuDrawer)menuDrawer).LabMenu;
            });
        }

        public void CallMap()
        {
            gameMap.CallMap();
        }
        private void CallStartMap()
        {
            gameMap = MapLazySingleton.GetMapIstanse();
            gameMap.CallMap();
        }

        private void ChooseHero()
        {
            Builder.PlayerConfiger playerConfiger = new Builder.PlayerConfiger();
            Console.WriteLine("Hello, Hero");
            Console.WriteLine("Who are you??");
            string Races = "1 => PZshnik\n2 => Lvasuk\n3 => Animeshnik\n4 => DeadInside\nAny character => PZ";
            Console.WriteLine(Races);
            char indx = Console.ReadKey().KeyChar;
            Console.WriteLine();
            player = playerConfiger.GetPlayerByClassIndex(indx);
            Console.Clear();
            player.ShowPlayer();
            MyRaceiver.player = this.player;
            MyRaceiver.GameUI = this.GameUI;
            MyRaceiver.CurrentMenu = this.CurrentMenu;
        }

        private void CreateWorld()
        {
            WorldHead = new PortalComponent("Black Hole");
            WorldHead.AddComponent(new PortalComponent("White Hole??"));
            IWorldComponent FirstLevel = new LocationComponent(new Location("???","easy","i don`t know","I DON`T KNOW!!",new List<string>()));
            IWorldComponent SecondLevel = new LocationComponent(new Location("Lviv", "easy", "12pm", "summer", new List<string>()));
            IWorldComponent Portal2 = new PortalComponent("!@)(*&(");
            FirstLevel.AddComponent(SecondLevel);
            SecondLevel.AddComponent(Portal2);
            WorldHead.AddComponent(FirstLevel);          
        }
        
        
        
    }
}
