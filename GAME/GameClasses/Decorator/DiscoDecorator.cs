using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GAME.GameClasses.Decorator
{
    [Serializable]
    class DiscoDecorator : PlayerDecorator
    {
        protected string strDisco = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\GameClasses\\Decorator\\Disco.txt");
        public DiscoDecorator(Player coolhero) : base(coolhero)
        {

        }
        public override void ShowPlayer()
        {

            SoundPlayerSingletone.GetPlayerIstanse().PlayByRelPath("\\Sound\\lmfao-party.wav");
            System.Threading.Thread.Sleep(2000);
            ConsoleColor backgroundColor = Console.BackgroundColor;
            ConsoleColor forgroundColor = Console.ForegroundColor;
            bool flag = true;
            for (int i = 0; i < 50; ++i)
            {
                Console.Clear();
                Console.WriteLine(strDisco);

                if (flag)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    flag = false;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    flag = true;
                }
               
                System.Threading.Thread.Sleep(10);
                
            }
            Console.Clear();
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = forgroundColor;
            base.ShowPlayer();
        }
        private void Disco()
        {
            
            SoundPlayerSingletone.GetPlayerIstanse().PlayByRelPath("\\Sound\\lmfao-party.wav");
        }
    }  
}

