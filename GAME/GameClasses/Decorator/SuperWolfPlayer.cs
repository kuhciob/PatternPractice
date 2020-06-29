using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Decorator
{
    [Serializable]
    class SuperWolfPlayer : WolfPlayer
    {
        public SuperWolfPlayer (Player coolhero) : base(coolhero)
        {

        }
        public override void ShowPlayer()
        {
            CoolHero.SetVoice("\\Sound\\Wolf.wav");
            CoolHero.SetName("Super" + CoolHero.GetName());
            base.ShowPlayer();
        }
    }
}
