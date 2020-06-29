using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    [Serializable]
    class SoundPlayerSingletone
    {
        private static SoundPlayerSingletone PlayerSinglton = null;
        private static SoundPlayer player;
        private static readonly object padlock = new object();
        private SoundPlayerSingletone()
        {
            player = new SoundPlayer();
            
        }
        public static SoundPlayerSingletone GetPlayerIstanse()                         
        {
            lock (padlock)
            {
                if (PlayerSinglton == null)
                {
                    PlayerSinglton = new SoundPlayerSingletone();
                } 
                return PlayerSinglton;
            }
        }
        public void PlayByFullPath(string songPath)
        {
            lock (padlock)
            {
                player.SoundLocation = songPath;
                player.LoadAsync();
                if (player.IsLoadCompleted)
                    player.Play();
            }
           
        }
        public void PlayByRelPath(string songRelPath)
        {
            lock (padlock)
            {
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory+songRelPath;
                player.LoadAsync();
                if (player.IsLoadCompleted)
                    player.Play();
            }

        }
        public void Stop()
        {
            lock (padlock)
                player.Stop();
        }
       
    }
}

