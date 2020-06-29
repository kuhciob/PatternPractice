using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Builder
{
    class Lvasuk : PlayerBuilder
    {
        private Player Gamer = new Player();
        public override void BuildStats()
        {
            Gamer.SetStats(new Stats(90, 70, 90, 85, 90, 80, 50));
        }
        public override void BuildSex()
        {
            Gamer.SetSex("male");
        }
        public override void BuildName()
        {
            Gamer.SetName("Ivan Boichuk");
        }
        public override void BuildSlogan()
        {
            Gamer.SetSlogan("I AM ALIVE!!!");
        }
        public override Player GetPlayer()
        {
            return Gamer;
        }
        public override void BuildVoice()
        {
            Gamer.SetVoice("\\Sound\\i_am_ALIVE.wav");
        }
    }
}
