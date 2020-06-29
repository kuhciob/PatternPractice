using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.SmallUI
{
    [Serializable]
    class SmallLightUI: ISmallUI
    {
        private ConsoleColor BackgrountColor = ConsoleColor.White;
        private ConsoleColor ForerountColor = ConsoleColor.Black;
        public override void SetStyle()
        {
            Console.BackgroundColor = BackgrountColor;
            Console.ForegroundColor = ForerountColor;
            Console.Clear();
        }
    }
}
