using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.CommandPattern
{
    [Serializable]
    public class Receiver
    {
        public IUserInterface GameUI;
        public Player player;
        public List<string> CurrentMenu;
        public Receiver(IUserInterface ui,Player hero,List<string> menu)
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
}
