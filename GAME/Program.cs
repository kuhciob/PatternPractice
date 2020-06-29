using GAME.GameClasses;
using GAME.GameClasses.UIFactory;
using GAME.Interfaces;
using GAME.Interfaces.UIFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GAME
{
    class Program
    {
              
        static void Main(string[] args)
        {
            GameFacade gameFacade = new GameFacade();
            gameFacade.StartGame();



        }
     
    }
}
