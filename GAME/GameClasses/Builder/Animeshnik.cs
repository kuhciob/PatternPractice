using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Builder
{
    class Animeshnik : PlayerBuilder
    {
        private Player Gamer = new Player();
        public override void BuildStats()
        {
            Gamer.SetStats(new Stats(10, 50, 10, 40, 60, 10, 100));
        }
        public override void BuildSex()
        {
            Gamer.SetSex("substance");
        }
        public override void BuildName()
        {
            Gamer.SetName("Naruto");
        }
        public override void BuildSlogan()
        {
            Gamer.SetSlogan("I LOVE ANIME!!!");
        }
        public override Player GetPlayer()
        {
            return Gamer;
        }
        public override void BuildVoice()
        {
            Gamer.SetVoice("\\Sound\\narutoVoice.wav");
        }
    }
}
