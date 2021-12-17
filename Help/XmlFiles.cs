using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Help
{
    /// <summary>
    /// Класс для работы с XML файлами, предназначенными для работы с классом CharBot
    /// </summary>
    public class XmlFiles
    {
        private static XmlSerializer formatter = new XmlSerializer(typeof(List<AskModel>));

        public static void Create(string[] parametrs, string filePath)
        {
            if (parametrs == null || filePath == null)
                throw new Exception("В конструктор XML файла передан не иницилизированный объект");
            List<AskModel> list = new List<AskModel>();
            for(int i = 0; i < parametrs.Length; i++)
                list.Add(new AskModel() { Id = i + 1, Ask = parametrs[i] });   
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, list);
            }
        }
        public static void Add(AskModel model, string filePath)
        {
            if (model == null || filePath == null)
                throw new Exception("При попытке добавить элемент в XML файл был передан не инициализированный объект");
            if (!File.Exists(filePath))
                throw new Exception("Попытка обращения к несуществующему файлу");
            List<AskModel> list;
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                list = (List<AskModel>)formatter.Deserialize(file);
            }
            if(list == null)
                Create(new string[] { model.Ask }, filePath);
            else
            {
                foreach (AskModel element in list)
                    if (element.Id == model.Id)
                        throw new Exception("Елемент с таким Id уже доавблен");
                list.Add(model);
                using(FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(file, list);
                }
            }
        }
        public static string Get(int id, string filePath)
        {
            if (filePath == null)
                throw new Exception("При попытке получить элемент из XML файла был передан не инициалированный объект");
            if (id <= 0)
                throw new Exception("Переданное значение id некорректно. Значение id должно быть больше 0");
            if (!File.Exists(filePath))
                throw new Exception("Попытка обращения к несуществующему файлу");
            List<AskModel> list;
            using(FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                list = (List<AskModel>)formatter.Deserialize(file);
            }
            if (list == null)
                throw new Exception("Файд пуст");
            foreach (AskModel element in list)
                if (element.Id == id)
                    return element.Ask;
            return null;
        }
    }
}
