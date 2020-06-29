﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GAME
{
    [Serializable]
    public class Player
    {
        private Stats Stats;
        private string Slogan;
        private string Sex;
        private string Name;
        private string VoiceRelPath;

        public void ShowStats()
        {
            Console.WriteLine("My Stats");
            Console.WriteLine(Stats.GetStatsString());

        }

        public virtual void ShowPlayer()
        {
            Console.WriteLine(Slogan);
            GetVoice();
            Console.WriteLine("My name is "+ Name);
            Console.WriteLine("I am " + Sex);
            ShowStats();
        }
        public string GetSlogan()
        {
            return Slogan;
        }
        public void SetStats( Stats stats){
            Stats = stats;
        }
        public Stats GetStats()
        {
            return Stats;
        }
        public void GetVoice()
        {
            GameClasses.SoundPlayerSingletone.GetPlayerIstanse().PlayByRelPath(VoiceRelPath);
        }
        public string GetName()
        {
            return Name;
        }

        public void SetSex(string sex)
        {
            this.Sex = sex;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetSlogan(string slogan)
        {
            this.Slogan = slogan;
        }
        public void SetVoice(string SoundRelPath)
        {
            VoiceRelPath= SoundRelPath;
        }
    }

}
