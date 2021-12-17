using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RepositoryLib
{
    public class LoggerRepository
    {
        private static XmlSerializer formatter = new XmlSerializer(typeof(List<LogModel>));
        public string Get()
        {
            List<LogModel> list;
            using(FileStream file = new FileStream("Errors/Error", FileMode.OpenOrCreate))
            {
                list = (List<LogModel>)formatter.Deserialize(file);
            }
            string result = "\nОшибки:\n";
            foreach (LogModel model in list)
                result += "Время: " + String.Format("{0:G}", model.Date) + "\n" + $"Ошибка: {model.ErrorText}\n";
            return result;
        }
    }
}
