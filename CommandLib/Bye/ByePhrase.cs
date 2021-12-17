using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Bye
{
    public class BuyPhrase
    {
        private IRepository _repository;
        public BuyPhrase(IRepository repository)
        {
            if (repository == null)
                throw new Exception("В конструктор \"ByePhrase\" передан не инициализированный репозиторий");
            _repository = repository;
        }
        public string Say()
        {
            return _repository.Get(new Random().Next(1, 2));
        }
    }
}
