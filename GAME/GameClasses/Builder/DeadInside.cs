using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Builder
{
    class DeadInside : PlayerBuilder
    {
        private Player Gamer = new Player();
        public override void BuildStats()
        {
            Gamer.SetStats(new Stats(5, 5, 5, 5, 10, 5, 15));
        }
        public override void BuildSex()
        {
            Gamer.SetSex("Tokyo Ghoul");
        }
        public override void BuildName()
        {
            Gamer.SetName("XXXGhoul");
        }
        public override void BuildSlogan()
        {
            Gamer.SetSlogan("zxc!! Donn`t care the game i am dead inside");
        }
        public override Player GetPlayer()
        {
            return Gamer;
        }
        public override void BuildVoice()
        {
            Gamer.SetVoice("\\Sound\\i-am-dead-inside.wav");
        }
    }
}
