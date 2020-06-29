using GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.UIMemento
{
    class Memento
    {
        private IUserInterface state;

        public IUserInterface GetState()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("UIMemento.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            state = (IUserInterface)formatter.Deserialize(stream);
            stream.Close();
            return state;
        }

        public void SetState(IUserInterface state)
        {
            this.state = state;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("UIMemento.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.state);
            stream.Close();
        }
    }
}
