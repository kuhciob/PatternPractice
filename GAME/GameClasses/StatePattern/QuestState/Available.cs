using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    class Available : State
    {
        public override void GetStatus()
        {
            Stars = QuestStars.One;
            ConsolePrinter.WriteColorText(String.Format("[ Avaliable ;) {0}/3 stars] ", ((int)Stars).ToString()), ConsoleColor.Cyan);
        }
        public override void Request()
        {
            Console.WriteLine("Quest is available. Do you want to start it?");
        }
    }
}
