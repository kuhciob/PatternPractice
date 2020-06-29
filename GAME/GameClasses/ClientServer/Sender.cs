using GAME.GameClasses.CommandPattern;
using GAME.GameClasses.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GAME.ClientServer
{
    class Sender
    {
        static int port = 8005; 
        static string address = "127.0.0.1"; 
        public static void SendCommand(Command command) {
            
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipPoint);
                object obj = new object();
                ClientServer.MyMessage message = ClientServer.CommadConverter.Serialize(command);
                ClientServer.CommadConverter.SerializeToFile(command);

                byte[] data = message.Data;
                socket.Send(data);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
