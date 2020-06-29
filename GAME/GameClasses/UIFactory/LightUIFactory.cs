using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME.Interfaces.UIFactory;
using GAME.GameClasses.WideUI;
using GAME.GameClasses.SmallUI;

namespace GAME.GameClasses.UIFactory
{
    class LightUIFactory : IuiFactory
    {
        public IWideUI BuildWideUI()
        {
            return new WideLightUI();
        }
        public ISmallUI BuildSmallUI()
        {
            return new SmallLightUI();
        }
    }
}
