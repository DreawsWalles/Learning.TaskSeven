using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.DownloadWebSite
{
    public class DownloadWebSiteCommand : ICommand
    {
        private DownloadWebSitePhrase _phrase;

        public DownloadWebSiteCommand(DownloadWebSitePhrase phraseSet)
        {
            if (phraseSet == null)
                throw new Exception("В конструктор \"DownloadWebSiteCommand\" команды передан не инициализированный класс получения ответа");
            _phrase = phraseSet;
        }

        public string Execute()
        {
            return _phrase.Say();
        }
    }
}
