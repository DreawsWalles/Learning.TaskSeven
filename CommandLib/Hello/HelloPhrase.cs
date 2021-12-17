using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Hello
{
    public class HelloPhrase
    {
        public string Say()
        {
            return DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 11 ? "Доброе утро" : DateTime.Now.Hour >= 11 && DateTime.Now.Hour <= 18 ? "Добрый день" : DateTime.Now.Hour > 18 && DateTime.Now.Hour < 21 ? "Добрый вечер" : "Доброй ночи";
        }
    }
}
