using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Hello
{
    public class HelloCommand : ICommand
    {
        private HelloPhrase _phrase;
        public HelloCommand(HelloPhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"HelloCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;
        }
        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
