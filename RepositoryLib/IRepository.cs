using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IRepository
    {
        void Add(AskModel model);
        string Get(int id);
    }
}
