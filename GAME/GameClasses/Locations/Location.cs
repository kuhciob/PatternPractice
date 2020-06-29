using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses
{
    class Location
    {
        public string Name  { get; private set; }
        public string Difficulty { get; private set; }
        public string DayTime { get; private set; }
        public string Season { get; private set; }
        public List<string> Resurses { get; private set; }
        public string Status { get; set; }

        public Location(string name, string diff, string daytime, string season, List<string> Res,string status= "unexplored")
        {
            Name = name;
            Difficulty = diff;
            DayTime = daytime;
            Season = season;
            Res = new List<string>(Res);
            Status = status;
        }
    }

    class foo : Location
    {
        public foo(string name, string diff, string daytime, string season, List<string> Res, string status = "unexplored") : base(name, diff, daytime, season, Res, status)
        {

        }
    }
}
