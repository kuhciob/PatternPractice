using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.SmallUI
{
    [Serializable]
    abstract class ISmallUI : IUserInterface
    {
        protected double GameHeight = DisplayHeight;
        protected double GameWidth = DisplayWidth;
        public override void SetResolution()
        {
            Console.SetWindowSize(Convert.ToInt32(Console.LargestWindowWidth / 4.0), Convert.ToInt32(Console.LargestWindowHeight / 4.0));
        }
    }
}
