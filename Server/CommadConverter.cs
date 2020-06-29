using GAME.GameClasses.CommandPattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class MyMessage
    {
        public byte[] Data { get; set; }
    }
    public class CommadConverter
    {
        public static MyMessage Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                MyMessage retmsg= new MyMessage { Data = memoryStream.ToArray() };
                memoryStream.Close();
                return retmsg;
            }
        }

        public static object Deserialize(MyMessage message)
        {
                using (MemoryStream memoryStream = new MemoryStream(message.Data))
                return (new BinaryFormatter()).Deserialize(memoryStream);               
        }
    }

}
