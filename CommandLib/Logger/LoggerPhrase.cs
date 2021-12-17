using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Logger
{
    public class LoggerPhrase
    {
        private LoggerRepository _repository;
        public LoggerPhrase()
        {
            _repository = new LoggerRepository();
        }
        public string Say()
        {
            return _repository.Get();
        }
    }
}
