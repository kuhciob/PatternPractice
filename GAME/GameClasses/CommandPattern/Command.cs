using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.CommandPattern
{
    [Serializable]
    abstract class Command
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
}
