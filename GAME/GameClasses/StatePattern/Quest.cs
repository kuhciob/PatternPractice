using GAME.GameClasses.StatePattern.QuestState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern
{
    class Quest
    {
        private string questName;
        private State Status;

        public Quest(string name)
        {
            questName = name;
            Status = new QuestState.Unavailable();
        }
        public Quest(string name,State status)
        {
            questName = name;
            Status = status;
        }
        public void ShowStatus()
        {
            Console.WriteLine(String.Format("'{0}'",questName.ToUpper()));
            Status.GetStatus();
        }
        public string GetName()
        {
            return questName;
        }

    }
}
