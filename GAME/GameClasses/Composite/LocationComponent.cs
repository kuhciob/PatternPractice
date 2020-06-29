using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Composer
{
    class LocationComponent:IWorldComponent
    {
        private Location Location;
        private List<IWorldComponent> WorldComponents=new List<IWorldComponent>();
        public LocationComponent(Location location)
        {
            Location = location;
        }
        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                string.Format("\'{0}\'\n Status:{1}\nDifficulty:{2}\nSeason:{3}\nTime of Day:{4}",
                Location.Name, Location.Status, Location.Difficulty, Location.Season, Location.DayTime)
            );
            if (WorldComponents.Count != 0)
            {
                stringBuilder.AppendLine("ways after\'" + Location.Name + "\':");
                foreach (var component in WorldComponents)
                {
                    stringBuilder.AppendLine(string.Format("[\'{0}\' WAY]", Location.Name));
                    stringBuilder.AppendLine(component.GetInfo());
                }
            }
           
            return stringBuilder.ToString();
        }
        public void AddComponent(IWorldComponent Node)
        {
            WorldComponents.Add(Node);
        }
    }
}
