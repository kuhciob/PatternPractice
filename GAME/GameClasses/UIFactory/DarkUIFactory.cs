using System;
using GAME.Interfaces.UIFactory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME.GameClasses.WideUI;
using GAME.GameClasses.SmallUI;

namespace GAME.GameClasses.UIFactory
{
    class DarkUIFactory : IuiFactory
    {
        public IWideUI BuildWideUI()
        {
            return new WideDarkUI();
        }
        public ISmallUI BuildSmallUI()
        {
            return new SmallDarkUI();
        }
    }
}
