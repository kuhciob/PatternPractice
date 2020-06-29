using GAME.GameClasses.CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME.GameClasses
{
    
    class KeyListener
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        private Thread Listener;
        private Receiver receiver;
        public void SetReceiver(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void StartListen()
        {
            Listener = new Thread(()=>Listen());
            Listener.Start();
        }
        public void StopListen()
        {
            Listener = new Thread(Listen);
            Listener.Abort();
        }
        private void Listen()
        {
            while (true)
            {
                Thread.Sleep(100);
                Command order=null;
          
                for (int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        switch ((Keys)i)
                        {
                            case Keys.Escape:
                                System.Environment.Exit(1);
                                break;
                            case Keys.F5:
                                order = new SaveCommand(receiver);
                                
                                break;
                            case Keys.F6:
                                order = new LoadCommand(receiver);
                                break;
                            default:
                                break;

                        }
                        if (order != null)
                        {
                            ClientServer.Sender.SendCommand(order);
                        }
                        
                    }
                        
                    
                }
            }
        }
    }
}
