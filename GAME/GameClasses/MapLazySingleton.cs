using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Media;
using GAME.Interfaces;

namespace GAME
{
    class MapLazySingleton : Map
    {
        private static MapLazySingleton MapInstanse = null;
        private Point Coordinates;
        private string ImageSrc;
        SoundPlayer player;
        private MapLazySingleton()
        {
            Coordinates = new Point(0, 0);
            ImageSrc = "/defaultMap.jpj";
            player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Sound\\Im_the_map.wav";
        }
        public static MapLazySingleton GetMapIstanse()
        {
            if (MapInstanse == null)
                MapInstanse = new MapLazySingleton();

            return MapInstanse;
        }

        public override Map GetMap()
        {
            return GetMapIstanse();
        }


        
        public override void CallMap()
        {
           
            player.Play();
            String Greeting =
                " If there is a place you got to go \n" +
                    "I am the one you need to know\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "I'm the Map!\n" +
                    "\n" +
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

        public void StopMusic()
        {
            player.Stop();
        }
    }
}
