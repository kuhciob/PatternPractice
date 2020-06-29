using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    [Serializable]
    public class Stats
    {
        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Intelligance { get; set; }
        public int Agility { get; set; }
        public int Lucky { get; set; }

        public Stats(int S,int P, int E, int C, int I, int A, int L)
        {
            Strength = S;       //Сила
            Perception = P;     //Сприйняття
            Endurance = E;      //Витривалість
            Charisma = C;       //Харизма
            Intelligance = I;   //Розвідка
            Agility = A;        //Спритність
            Lucky = L;          //Везіння
        }

        public string GetStatsString()
        {
            PropertyInfo[] _PropertyInfos = null;
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }
}
