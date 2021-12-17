using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.FakeRepository
{
    public class FakeHelpRepository : IRepository
    {
        public void Add(AskModel model)
        {
            throw new Exception("Данный метод не поддерживается в данной реализации репозитория");
        }

        public string Get(int id)
        {
            return "Список доступных команд:\n" +
                    "1. Поздороваться с ботом (например \"Привет\")\n" +
                    "2. Попрощаться с ботом (например \"Пока\")\n" +
                    "3. Анекдот\n" +
                    "4. Спроси как меня зовут\n" +
                    "5. Спроси который сейчас час\n" +
                    "6. -help\n" +
                    "7. *Команда не распознана* (бот ответит вам афоризмом)";
        }
    }
}
