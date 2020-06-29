using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.StatePattern.QuestState
{
    abstract class State
    {
        protected QuestStars Stars;

        public abstract void GetStatus();
        public abstract void Request();
        

    }

    enum QuestStars { 
        Null=0,
        One=1,
        Two=2,
        Tree=3
    }

}
