using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.UIMemento
{
    class Originator
    {
        private IUserInterface state;

        public Memento CreateMemento()
        {
            Memento m = new Memento();
            m.SetState(state);
            return m;
        }

        public void SetMemento(Memento m)
        {
            state = m.GetState();
        }

        public void SetState(IUserInterface state)
        {
            this.state = state;
        }
        public IUserInterface GetState()
        {
            return state;
        }
    }
}
