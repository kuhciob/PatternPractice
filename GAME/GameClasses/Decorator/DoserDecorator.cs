using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GAME.GameClasses.Decorator
{
    [Serializable]
    class DoserDecorator : PlayerDecorator
    {
        public DoserDecorator(Player coolhero) : base(coolhero)
        {

        }
        public override void ShowPlayer()
        {
            for(int i = 0; i < 500; ++i)
            {
                //Console.Clear();
                Console.WriteLine("IT is  DOS ATTACK ^^O ^^O ^^O");
                base.ShowPlayer();
                Thread.Sleep(10);
            }
            
        }
    }
}
