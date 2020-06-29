using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForServer.PlayerMemento
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
    }
}
