using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class UnitOfWork
    {
        private IRepository? _aphorismsRepository;
        private IRepository? _myNameRepository;
        private IRepository? _jokeRepository;
        private IRepository? _byeRepository;
        private IRepository? _helpRepository;
        private IRepository? _downloadWebSiteRepository;
        public UnitOfWork(IRepository AphorismsRepository, IRepository MyNameRepository, IRepository JokeRepository, IRepository ByeRepository, IRepository HelpRepository, IRepository DownloadWebSiteRepository)
        {
            if (AphorismsRepository == null || MyNameRepository == null || JokeRepository == null || ByeRepository == null || HelpRepository == null || DownloadWebSiteRepository == null)
                throw new Exception("При попытке инициализации \"UnitOfWork\" был передан не инициализированный объект");
            _aphorismsRepository = AphorismsRepository;
            _myNameRepository = MyNameRepository;
            _jokeRepository = JokeRepository;
            _byeRepository = ByeRepository;
            _helpRepository = HelpRepository;
            _downloadWebSiteRepository = DownloadWebSiteRepository;
        }
        public IRepository Aphorisms
        {
            get
            {
                if (_aphorismsRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _aphorismsRepository;
            }
        }
        public IRepository NyName
        {
            get
            {
                if(_myNameRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _myNameRepository;
            }
        }
        public IRepository Joke
        {
            get
            {
                if(_jokeRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _jokeRepository;
            }
        }
        public IRepository Bye
        {
            get
            {
                if(_byeRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _byeRepository;
            }
        }
        public IRepository Help
        {
            get
            {
                if(_helpRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _helpRepository;
            }
        }
        public IRepository DownLoadWebSite
        {
            get
            {
                if(_downloadWebSiteRepository == null)
                    throw new Exception("Попытка обратиться к неинициализированному объекту");
                return _downloadWebSiteRepository;
            }
        }
    }
}
