using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    interface IController
    {
        void PauseGame();
        void ResumeGame();
        void ExitGame();
        void SkipDialog();

    }
}
