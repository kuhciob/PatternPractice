using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    class ConsoleDEMOControler : IController
    {
        public void ExitGame()
        {
            System.Environment.Exit(1);
        }

        public void PauseGame()
        {
            throw new NotImplementedException();
        }

        public void ResumeGame()
        {
            throw new NotImplementedException();
        }

        public void SkipDialog()
        {
            throw new NotImplementedException();
        }
    }
}
