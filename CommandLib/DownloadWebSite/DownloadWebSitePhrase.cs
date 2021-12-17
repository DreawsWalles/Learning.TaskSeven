using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.DownloadWebSite
{
    public class DownloadWebSitePhrase
    {
        private IRepository _repository;

        public DownloadWebSitePhrase(IRepository repository)
        {
            if (repository == null)
                throw new Exception("В конструктор \"DownloadWebSitePhrase\" передан не инициализированный репозиторий");
            _repository = repository;
        }
        public string Say()
        {
            return _repository.Get(0);
        }
    }
}
