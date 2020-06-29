using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    [Serializable]
    class PlayerDecorator : Player
    {
        protected Player CoolHero;
        public PlayerDecorator(Player coolhero)
        {
            CoolHero = coolhero;
        }
        public override void ShowPlayer()
        {
            CoolHero.ShowPlayer();
        }
    }
}
