using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    class Active : State
    {
        public override void GetStatus()
        {
            Stars = QuestStars.Two;
            ConsolePrinter.WriteColorText(String.Format("[ Active :| {0}/3 stars] ", ((int)Stars).ToString()),ConsoleColor.Yellow);
        }
        public override void Request()
        {
            Console.WriteLine("Quest is activated. May the Force be with you");
        }
    }
}
