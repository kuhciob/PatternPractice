using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.CommandPattern
{
    [Serializable]
    class LoadCommand : Command
    {
        public LoadCommand(Receiver receiver) : base(receiver)
        {

        }
        public override void Execute()
        {
            Console.WriteLine("Loading ...");
            base.receiver.Load();
            Console.Clear();
            Console.WriteLine("Loaded .");
        }
    }
}
