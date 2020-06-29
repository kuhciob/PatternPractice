

using ForServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Server
{
    class MyServer2
    {
        static int port = 8005;
        //static GameClasses.GameFacade game;

        public static void Run()
        {
            //game = gameFacade;
            Thread server = new Thread(SicretRun);
            server.Start();
            server.Join();
        }
        public static void SicretRun()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                while (true)
                {
                    Socket handler = listenSocket.Accept();

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];
                    Command command = null;
                    do
                    {
                        bytes = handler.Receive(data);
                        MyMessage msg = new MyMessage();
                        msg.Data = data;
                        command = (Command)CommadConverter.Deserialize(msg);
                        SaveManager saveManager = new SaveManager();
                        saveManager.SetCommand(command);
                        saveManager.Execute();

                        //Mediator mediator = new Mediator();
                        //SaveLogger saveLogger = new SaveLogger(mediator);
                        //LoadLogger loadLogger = new LoadLogger(mediator);
                        //if (command is SaveCommand)
                        //{
                        //    saveLogger.Send(String.Format("[{0}] Game Saved.", DateTime.Now));
                        //}
                        //else
                        //if (command is LoadCommand)
                        //{
                        //    saveLogger.Send(String.Format("[{0}] Game Loaded.", DateTime.Now));
                        //}
                        //else
                        //{
                        //    saveLogger.Send(String.Format("[{0}] {1}.", DateTime.Now, command.GetType().Name.ToString()));
                        //}
                    }
                    while (handler.Available > 0);


                    //string message = "200 OK";
                    //data = Encoding.Unicode.GetBytes(message);
                    //handler.Send(data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
