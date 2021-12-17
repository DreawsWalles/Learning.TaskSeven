using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.FakeRepository
{
    public class FakeByeRepository : IRepository
    {
        public void Add(AskModel model)
        {
            throw new Exception("Данный метод не поддерживается в данной реализации репозитория");
        }
        private static Dictionary<int, string> _command = new Dictionary<int, string>
        {
            {1, "Пока" },
            {2, "До свидания" }
        };
        public string Get(int id)
        {
            if (id < 1 || id > 2)
                throw new Exception("При попытке полечения прощания был передан некорректный id. Значение id должно быть в диапазоне от 1 до 2");
            return _command[id];
        }
    }
}
