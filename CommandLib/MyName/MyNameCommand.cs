using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.MyName
{
    public class MyNameCommand : ICommand
    {
        private MyNamePhrase _phrase;

        public MyNameCommand(MyNamePhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"MyNameCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
