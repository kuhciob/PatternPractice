using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Builder
{
    class PZshnik : PlayerBuilder
    {
        private Player Gamer = new Player();
        public override void BuildStats()
        {
            Gamer.SetStats(new Stats(20, 60, 10, 35, 90, 40, 60));
        }
        public override void BuildSex()
        {
            Gamer.SetSex("essence");
        }
        public override void BuildName()
        {
            Gamer.SetName("PZshnik");
        }
        public override void BuildSlogan()
        {
            Gamer.SetSlogan("OHH, Hello there!!");
        }
        public override Player GetPlayer()
        {
            return Gamer;
        }
        public override void BuildVoice()
        {
            Gamer.SetVoice("\\Sound\\shrek-oh-hello-there.wav");
        }
    }
}
