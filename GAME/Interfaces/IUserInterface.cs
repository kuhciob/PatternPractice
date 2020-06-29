using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GAME.Interfaces
{
    [Serializable]
    public abstract class IUserInterface
    {
        
        protected static readonly double DisplayHeight = SystemParameters.PrimaryScreenHeight;
        protected static readonly double DisplayWidth = SystemParameters.PrimaryScreenWidth;
        
        public abstract void SetStyle();
        public abstract void SetResolution();
        
    }
}
