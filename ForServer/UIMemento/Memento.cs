using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForServer.UIMemento
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
