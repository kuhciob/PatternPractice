using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForServer
{
    interface IMenuDrawer
    {
        string DrawMenu(List<string> items);
    }
}
