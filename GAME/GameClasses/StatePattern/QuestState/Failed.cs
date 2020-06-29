using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    class Failed : State
    {
        public override void GetStatus()
        {
            Stars = QuestStars.Null;
            ConsolePrinter.WriteColorText(String.Format("[ Failed >:( {0}/3 stars] ", ((int)Stars).ToString()), ConsoleColor.Red);
        }
        public override void Request()
        {
            Console.WriteLine("Looser (^^o)");
        }
    }
}
