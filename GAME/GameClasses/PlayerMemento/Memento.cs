using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.PlayerMemento
{
    class Memento
    {
        private Player state;

        public Player GetState()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerMemento.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            state = (Player)formatter.Deserialize(stream);
            stream.Close();
            return state;
        }

        public void SetState(Player state)
        {
            this.state = state;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerMemento.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.state);
            stream.Close();
        }
    }
}
