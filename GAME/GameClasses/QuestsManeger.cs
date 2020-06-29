using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    [Serializable]
    class QuestsManeger
    {
        private List<StatePattern.Quest> Quests=new List<StatePattern.Quest>();

        public void AddQuest(StatePattern.Quest quest)
        {
            Quests.Add(quest);
        }
        public void CreateStartQuests()
        {
            Quests.Add(new StatePattern.Quest("Training", new StatePattern.QuestState.Active()));
            Quests.Add(new StatePattern.Quest("No PZ", new StatePattern.QuestState.Available()));
            Quests.Add(new StatePattern.Quest("Everest", new StatePattern.QuestState.Unavailable()));
            Quests.Add(new StatePattern.Quest("Have good sleep", new StatePattern.QuestState.Failed()));
            Quests.Add(new StatePattern.Quest("Do not die", new StatePattern.QuestState.Completed()));
        }
        public List<string> GetQuestNamesList()
        {
            List<string> menu = new List<string>();
            foreach (StatePattern.Quest quest in Quests)
                menu.Add(quest.GetName());
            return menu;
        }
        public void ShowQuests()
        {
            foreach (StatePattern.Quest quest in Quests)
                quest.ShowStatus();
        }
    }
}
