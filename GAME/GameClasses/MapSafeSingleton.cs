using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Media;
using System.Threading;
using GAME.Interfaces;

namespace GAME
{
    class MapSafeSingleton : Map
    {
        private static MapSafeSingleton MapInstanse = null;
        private Point Coordinates;
        private string ImageSrc;
        SoundPlayer player;
        private static readonly object padlock = new object();
        private MapSafeSingleton()
        {
            Coordinates = new Point(0, 0);
            ImageSrc = "/defaultMap.jpj";
            player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Sound\\Im_the_map.wav";
        }
        public static MapSafeSingleton GetMapIstanse()
        {
            lock (padlock)
            {
                if (MapInstanse == null)
                    MapInstanse = new MapSafeSingleton();
                return MapInstanse;
            }
        }

        public override Map GetMap()
        {
            return GetMapIstanse();
        }


        public override void CallMap()
        {
            lock (padlock)
            {
                Thread.Sleep(100);
                player.Play();
                String Greeting =
                    " If there is a place you got to go \n" +
                    "I am the one you need to know\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "\n"+
                    "If there is a place you got to get\n" +
                    "I can get you there I bet\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n";
                Console.WriteLine(Greeting);
                string coordinates = String.Format("My coordinates is ( {0} , {1} )", Coordinates.X, Coordinates.Y);
                Console.WriteLine(coordinates);
                Console.WriteLine("Press 's' to stop this DISCO");
                string stop = Console.ReadLine();
                if (stop == "s")
                    StopMusic();
            }
            
        }

        public void StopMusic()
        {
            lock (padlock)
                player.Stop();
        }
    }
}
