using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    class Unavailable : State
    {
        public Unavailable()
        {
            Stars = QuestStars.Null;
        }
        public override void GetStatus()
        {
            ConsolePrinter.WriteColorText(String.Format("[ Unavailable 0_o ]"), ConsoleColor.DarkBlue);
        }
        public override void Request()
        {
            Console.WriteLine("Hmm ??");
        }
    }
}
