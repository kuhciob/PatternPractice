using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    abstract class PlayerBuilder
    {
        public abstract void BuildStats();
        public abstract void BuildSex();
        public abstract void BuildName();
        public abstract void BuildSlogan();
        public abstract void BuildVoice();
        abstract public Player GetPlayer();
    }
}
