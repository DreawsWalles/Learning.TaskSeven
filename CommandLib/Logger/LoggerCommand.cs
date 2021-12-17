using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Logger
{
    public class LoggerCommand : ICommand
    {
        private LoggerPhrase _phrase;
        public LoggerCommand(LoggerPhrase phraseSet)
        {
            _phrase = phraseSet;
        }
        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
