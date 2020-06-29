using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Mediator
{
    public abstract class Logger
    {
        protected Mediator mediator;
        public Logger(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
    public class SaveLogger : Logger
    {
        public SaveLogger(Mediator mediator): base(mediator)
        {
        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Log(string message)
        {
            File.AppendAllText("Savelog.txt", message);            
        }
    }
    public class LoadLogger : Logger
    {
        public LoadLogger(Mediator mediator) : base(mediator)
        {
        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Log(string message)
        {
            File.AppendAllText("Loadlog.txt", message);
        }
    }
    public class CommandLogger : Logger
    {
        public CommandLogger(Mediator mediator) : base(mediator)
        {
        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Log(string message)
        {
            File.AppendAllText("Log.txt", message);
        }
    }
}
