using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.JSONRepository
{
    public class JSONMyNameRepository : IRepository
    {
        public JSONMyNameRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/MyName"))
            {
                AskModel[] parametrs = new AskModel[]
                {
                    new AskModel(){ Id = 1, Ask = "Шарпик" }
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/MyName");
            }
        }
        public void Add(AskModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить элемент в JSON репозиторий бьл передан не инициализированый объект");
            JsonFiles.Add(model, "JSONRepository/MyName");
        }

        public string Get(int id)
        {
            if (id != 1)
                throw new Exception("При попытке получения имени бота из JSON репозитория был передан некорректный id. Значение id должно иметь значение 1");
            return JsonFiles.Get(id, "JSONRepository/MyName").Ask;
        }
    }
}
