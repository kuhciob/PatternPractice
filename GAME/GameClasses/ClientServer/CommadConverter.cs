using GAME.GameClasses.CommandPattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GAME.ClientServer
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
                return new MyMessage { Data = memoryStream.ToArray() };
            }

        }
        public static void SerializeToFile(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }
        public static object DeSerializeToFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            object obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        public static object Deserialize(MyMessage message)
        {
            using (MemoryStream memoryStream = new MemoryStream(message.Data))
            {
                return (new BinaryFormatter()).Deserialize(memoryStream);

            }
        }
    }

}
