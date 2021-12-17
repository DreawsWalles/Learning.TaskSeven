using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Help
{
    public class HelpPhrase
    {
        private IRepository _repository;

        public HelpPhrase(IRepository repository)
        {
            if (repository == null)
                throw new Exception("В конструктор \"HelpPhrase\" передан не инициализированный репозиторий");
            _repository = repository;
        }
        public string Say()
        {
            return _repository.Get(0);
        }
    }
}
