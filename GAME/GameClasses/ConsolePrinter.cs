using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    static class ConsolePrinter
    {
        static public void WriteColor(string outstr, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            ConsoleColor native_backgroundColor = Console.BackgroundColor;
            ConsoleColor native_foregroundColor = Console.ForegroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.WriteLine(outstr);

            Console.BackgroundColor = native_backgroundColor;
            Console.ForegroundColor = native_foregroundColor;
        }
        static public void WriteColorText(string outstr, ConsoleColor foregroundColor)
        {
            ConsoleColor native_foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = foregroundColor;

            Console.WriteLine(outstr);

            Console.ForegroundColor = native_foregroundColor;
        }
        static public void WriteColorBack(string outstr, ConsoleColor backgroundColor)
        {
            ConsoleColor native_backgroundColor = Console.BackgroundColor;

            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(outstr);

            Console.BackgroundColor = native_backgroundColor;
        }
    }
}
