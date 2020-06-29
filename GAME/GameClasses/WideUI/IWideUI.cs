using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.WideUI
{
    [Serializable]
    abstract class IWideUI: IUserInterface
    {
        protected double GameHeight = DisplayHeight;
        protected double GameWidth = DisplayWidth;
        public override void SetResolution()
        {
            Console.SetWindowSize(Convert.ToInt32(Console.LargestWindowWidth ), Convert.ToInt32(Console.LargestWindowHeight));
        }
    }
}
