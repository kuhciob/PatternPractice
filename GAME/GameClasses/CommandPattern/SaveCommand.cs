using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.CommandPattern
{
    [Serializable]
    class SaveCommand : Command
    {
        public SaveCommand(Receiver receiver) : base(receiver)
        {

        }
        public override void Execute()
        {
            Console.WriteLine("Saving ...");
            base.receiver.Save();
            Console.Clear();
            Console.WriteLine("Saved .");
        }
    }
}
