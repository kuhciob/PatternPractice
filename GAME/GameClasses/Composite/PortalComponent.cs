using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Composer
{
    class PortalComponent: IWorldComponent
    {
        private string Name;
        private List<IWorldComponent> WorldComponents=new List<IWorldComponent>();
        public PortalComponent(string PortalName)
        {
           Name = PortalName;
        }
        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                string.Format("Portal:\'{0}\'", Name)
            );
            if (WorldComponents.Count != 0)
            {
                stringBuilder.AppendLine("ways after\'" + Name + "\':");
                foreach (var component in WorldComponents)
                {
                    stringBuilder.AppendLine(string.Format("[Portal\'{0}\' WAY]", Name));
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
