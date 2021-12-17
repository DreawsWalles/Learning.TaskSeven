using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Help
{
    public class HelpCommand : ICommand
    {
        private HelpPhrase _phrase;
        public HelpCommand(HelpPhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"HelpCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
