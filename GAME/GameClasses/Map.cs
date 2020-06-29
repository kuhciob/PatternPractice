using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Runtime.CompilerServices;

namespace GAME
{
    abstract class Map
    {
        private Map MapInstanse = null;
        private Point Coordinates;
        virtual public Map GetMap()
        {
            return MapInstanse;
        }
        public Point GetCoordinates()
        {
            return Coordinates;
        }
        virtual public void SetCoordinates(Point point)
        {
             Coordinates = new Point(point.X, point.Y);
        }
        virtual public void SetCoordinates(double x, double y)
        {
            Coordinates = new Point(x, y);
        }

        virtual public void CallMap()
        {
            string coordinates = String.Format("My coordinates is ( {0} , {1} )", Coordinates.X, Coordinates.Y);
            Console.WriteLine(coordinates);
        }



    }
}
