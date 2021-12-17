using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Help
{
    public class JsonFiles
    {
        public static void Create(List<AskModel> parametrs, string filePath)
        {
            if (parametrs == null || filePath == null)
                throw new Exception("В конструктор JSON файла передан не иницилизированный объект");
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<AskModel>>(file, parametrs);
            }
        }
        public static void Add(AskModel model, string filePath)
        {
            if (model == null || filePath == null)
                throw new Exception("При попытке добавить элемент в JSON файл был передан не инициализированный объект");
            if (!File.Exists(filePath))
                throw new Exception("Попытка обращения к несуществующему файлу");
            List<AskModel> tmp = GetAll(filePath);
            if (tmp == null)
                Create(new List<AskModel>() { model }, filePath);
            foreach (AskModel element in tmp)
                if (element.Id == model.Id)
                    throw new Exception("Елеменнт с таким Id уже добавлен");
            tmp.Add(model);
            using(FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<AskModel>>(file, tmp);
            }
        }
        public static AskModel Get(int id, string filePath)
        {
            if (filePath == null)
                throw new Exception("При попытке получить элемент из JSON файла был передан не инициалированный объект");
            if (id <= 0)
                throw new Exception("Переданное значение id некорректно. Значение id должно быть больше 0");
            if (!File.Exists(filePath))
                throw new Exception("Попытка обращения к несуществующему файлу");
            List<AskModel> tmp = GetAll(filePath);
            if (tmp == null)
                throw new Exception("Данный файл пуст");
            foreach (AskModel element in tmp)
                if (element.Id == id)
                    return element;
            return null;
        }
        private static List<AskModel> GetAll(string filePath)
        {
            if (filePath == null)
                throw new Exception("При попытке получить все содержимое JSON файла был передан не инициализированный объект");
            if (!File.Exists(filePath))
                throw new Exception("Попытка обращения к несуществующему файлу");
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<AskModel>>(file);
            }
        }
    }
}
