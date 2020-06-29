using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.CommandPattern
{
    [Serializable]
    class SaveManager
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
