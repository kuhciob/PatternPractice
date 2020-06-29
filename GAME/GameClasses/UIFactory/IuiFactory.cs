using GAME.GameClasses;
using GAME.GameClasses.SmallUI;
using GAME.GameClasses.WideUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.Interfaces.UIFactory
{
    interface IuiFactory
    {
        IWideUI BuildWideUI();
        ISmallUI BuildSmallUI();
    }
}
