﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.WideUI
{
    [Serializable]
    class WideDarkUI : IWideUI
    {
        private ConsoleColor BackgrountColor = ConsoleColor.Black;
        private ConsoleColor ForerountColor = ConsoleColor.White;
        public override void SetStyle()
        {
            Console.BackgroundColor = BackgrountColor;
            Console.ForegroundColor = ForerountColor;
            Console.Clear();
        }
    }
}
