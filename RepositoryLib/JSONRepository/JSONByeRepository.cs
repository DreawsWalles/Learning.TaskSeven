using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.JSONRepository
{
    public class JSONByeRepository : IRepository
    {
        public JSONByeRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/Bye"))
            {
                AskModel[] parametrs = new AskModel[] 
                {
                    new AskModel(){ Id = 1, Ask = "Пока"},
                    new AskModel(){ Id = 2, Ask = "До свидания"}
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/Bye");
            }
        }
        public void Add(AskModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить элемент в JSON репозиторий бьл передан не инициализированый объект");
            JsonFiles.Add(model, "JSONRepository/Bye");
        }

        public string Get(int id)
        {
            if (id < 1 || id > 2)
                throw new Exception("При попытке полечения прощания из JSON репозитория был передан некорректный id. Значение id должно быть в диапазоне от 1 до 2");
            return JsonFiles.Get(id, "JSONRepository/Bye").Ask;
        }
    }
}
