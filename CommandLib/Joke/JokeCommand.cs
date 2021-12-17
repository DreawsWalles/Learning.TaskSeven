using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Joke
{
    public class JokeCommand : ICommand
    {
        private JokePhrase _phrase;
        public JokeCommand(JokePhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"JokeCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;    
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
