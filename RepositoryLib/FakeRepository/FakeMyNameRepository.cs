using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.FakeRepository
{
    public class FakeMyNameRepository : IRepository
    {
        public void Add(AskModel model)
        {
            throw new Exception("Данный метод не поддерживается в данной реализации репозитория");
        }

        public string Get(int id)
        {
            return "Шарпик";
        }
    }
}
