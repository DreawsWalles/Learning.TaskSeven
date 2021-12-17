using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Time
{
    public class TimeCommand : ICommand
    {
        private  TimePhrase _phrase;
        public TimeCommand(TimePhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"TimeCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
