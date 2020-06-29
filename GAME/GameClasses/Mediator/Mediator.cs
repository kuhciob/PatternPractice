using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME.GameClasses.Mediator
{
    public class Mediator
    {
        private SaveLogger saveLogger ;
        private LoadLogger loadLogger;
        private CommandLogger commandLogger;
        public void SetLogers(SaveLogger slog, LoadLogger llog, CommandLogger clog)
        {
            saveLogger = slog;
            loadLogger = llog;
            commandLogger=clog;
        }
        public SaveLogger SaveLogger
        {
            set { saveLogger = value; }
        }
        public LoadLogger LoadLogger
        {
            set { loadLogger = value; }
        }
        public CommandLogger CommandLogger
        {
            set { commandLogger = value; }
        }
        public void Send(string message, Logger logger)
        {
            if (logger == saveLogger)
            {
                commandLogger.Log(message);
                saveLogger.Log(message);
            }
            else
            if (logger == loadLogger)
            {
                commandLogger.Log(message);
                loadLogger.Log(message);
            }
        }
    }

}
