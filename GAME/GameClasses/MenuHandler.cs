using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    [Serializable]
    class MenuHandler
    {
        private Hashtable Delegates = new Hashtable();
        public delegate void VoidFunction();
        public bool HandleItem(string item)
        {
            if (Delegates.ContainsKey(item))
            {
                ((VoidFunction)Delegates[item])();
                return true;
            }
            return false;
        }
        public void AddDelegate(string MenuItem , VoidFunction function)
        {
            Delegates.Add(MenuItem, function);
        }

    }
}
