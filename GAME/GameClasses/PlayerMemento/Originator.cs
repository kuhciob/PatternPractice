using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.PlayerMemento
{
    class Originator
    {
        private Player state;

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

        public void SetState(Player state)
        {
            this.state = state;
        }
        
        public Player GetState()
        {
            return state;
        }
    }
}
