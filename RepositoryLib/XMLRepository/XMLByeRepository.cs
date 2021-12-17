using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.XMLRepository
{
    public class XMLByeRepository : IRepository
    {
        public XMLByeRepository()
        {
            if (!Directory.Exists("XMLRepository"))
                Directory.CreateDirectory("XMLRepository");
            if (!File.Exists("XMLRepository/Bye"))
            {
                string[] parametrs = new string[] { "Пока", "До свидания" };
                XmlFiles.Create(parametrs, "XMLRepository/Bye");
            }
        }

        public void Add(AskModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить элемент в JSON репозиторий бьл передан не инициализированый объект");
            XmlFiles.Add(model, "XMLRepository/Bye");
        }

        public string Get(int id)
        {
            if (id < 1 || id > 2)
                throw new Exception("При попытке полечения прощания из XML репозитория был передан некорректный id. Значение id должно быть в диапазоне от 1 до 2");
            return XmlFiles.Get(id, "XMLRepository/Bye");
        }
    }
}
