using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.UIMemento
{
    class Caretaker
    {
        private static readonly Originator originator = new Originator();
        private static Memento save = new Memento();
        public static void SaveState(Originator orig)
        {
            save = orig.CreateMemento();
        }
        public static void RestoreState(Originator orig)
        {
            orig.SetMemento(save);
        }
        public static void RestoreState()
        {
            originator.SetMemento(save);
        }
    }
}
