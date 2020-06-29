using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    class Completed : State
    {
        public override void GetStatus()
        {
            Stars = QuestStars.Tree;
            ConsolePrinter.WriteColorText(String.Format("[ Completed <3 {0}/3 stars] ", ((int)Stars).ToString()), ConsoleColor.Green);
        }
        public override void Request()
        {
            Console.WriteLine("Well done");

        }
    }
}
