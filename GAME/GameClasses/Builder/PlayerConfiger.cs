using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Builder
{
    class PlayerConfiger
    {
        private PlayerBuilder playerBuilder;
        public void SetPlayerBuilder(PlayerBuilder pb)
        {
            playerBuilder = pb;
        }
        public Player GetPlayer()
        {
            return playerBuilder.GetPlayer();
        }
        public Player GetPlayerByClassIndex(char indx)
        {
            switch (indx)
            {
                case '1':
                    playerBuilder = new PZshnik();
                    break;
                case '2':
                    playerBuilder = new Lvasuk();
                    break;
                case '3':
                    playerBuilder = new Animeshnik();
                    break;
                case '4':
                    playerBuilder = new DeadInside();
                    break;
                default: playerBuilder = new PZshnik(); break;
            }
            ConfiguratePlayer();
            return playerBuilder.GetPlayer();
        }

        public void ConfiguratePlayer()
        {
            playerBuilder.BuildName();
            playerBuilder.BuildSex();
            playerBuilder.BuildStats();
            playerBuilder.BuildSlogan();
            playerBuilder.BuildVoice();
        }


    }
}
