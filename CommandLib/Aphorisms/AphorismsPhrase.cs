using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommandLib.Aphorisms
{
    public class AphorismsPhrase
    {
        private IRepository _repository;
        public AphorismsPhrase(IRepository repository)
        {
            if (repository == null)
                throw new Exception("В конструктор \"AphorismPhrase\" передан не инициализированный репозиторий");
            _repository = repository;
        }
        public string Say()
        {
            return _repository.Get(new Random().Next(1, 20));
        }
    }
}
