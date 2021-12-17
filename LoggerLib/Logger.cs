using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoggerLib
{
    public class Logger
    {
        private static XmlSerializer formatter = new XmlSerializer(typeof(List<LogModel>));
        public Logger()
        {
            if (!Directory.Exists("Errors"))
                Directory.CreateDirectory("Errors");
            if (!File.Exists("Errors/Error"))
               using(FileStream file = new FileStream("Errors/Error", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(file, new List<LogModel>());
                }
        }
        public void Log(string ErrorText)
        {
            if (ErrorText == null)
                throw new ArgumentNullException(ErrorText);
            List<LogModel> list;
            using(FileStream file = new FileStream("Errors/Error", FileMode.OpenOrCreate))
            {
                list = (List<LogModel>)formatter.Deserialize(file);
            }
            list.Add(new LogModel() { ErrorText = ErrorText, Date = DateTime.Now });
            using (FileStream file = new FileStream("Errors/Error", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, list);
            }
        }
    }
}
