using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Decorator
{
    [Serializable]
    class WolfPlayer : PlayerDecorator
    {
        protected string strWolfImage= File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+ "\\GameClasses\\Decorator\\WolfImage.txt");
        public WolfPlayer(Player coolhero) : base(coolhero)
        {
            
        }
        public override void ShowPlayer()
        {
            CoolHero.SetSlogan("Aufff!!!" + CoolHero.GetSlogan());
            CoolHero.SetName("Wolf" + CoolHero.GetName());
            Console.WriteLine(strWolfImage);
            base.ShowPlayer();
        }

    }
}
