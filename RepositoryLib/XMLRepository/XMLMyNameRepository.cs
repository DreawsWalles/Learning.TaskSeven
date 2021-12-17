using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.XMLRepository
{
    public class XMLMyNameRepository : IRepository
    {
        public XMLMyNameRepository()
        {
            if(!Directory.Exists("XMLRepository"))
                Directory.CreateDirectory("XMLRepository");
            if (!File.Exists("XMLRepository/MyName"))
                XmlFiles.Create(new string[] { "Шарпик" }, "XMLRepository/MyName");
        }

        public void Add(AskModel model)
        {
            if (model == null)
                throw new Exception("При попытке добавить элемент в JSON репозиторий бьл передан не инициализированый объект");
            XmlFiles.Add(model, "XMLRepository/MyName");
        }

        public string Get(int id)
        {
            if (id != 1)
                throw new Exception("При попытке получения имени бота из XML репозитория был передан некорректный id. Значение id должно иметь значение 1");
            return XmlFiles.Get(id, "XMLRepository/MyName");
        }
    }
}
