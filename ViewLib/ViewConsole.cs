using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    public class ViewConsole : IView
    {
        public async void ViewAnswer(string question, string answer)
        {
            if (question == null || answer == null)
                throw new Exception("При попытке отобразить содержимое запроса были переданы не инициализированные объекты");
            Console.WriteLine($"\n\nОтвет на запрос \"{question}\": {answer}");
            Console.Write("You->");
            if (question.ToLower() != "пока" || question.ToLower() != "до свидания")
                Environment.Exit(0);
        }

        public void ViewHistory(List<HistoryModel> parametrs)
        {
            if (parametrs == null)
                throw new Exception("При ипопытке отобразить историю запросов был передан не инициализированный объект");
            foreach (HistoryModel model in parametrs)
            {
                Console.WriteLine("{0:g}", model.dateTime);
                Console.WriteLine($"You->{model.Question}");
                Console.WriteLine($"Bot->{model.BotMessage}");
                Console.WriteLine();
            }
        }
        public void ViewError(string message)
        {
            if (message == null)
                throw new Exception("При попытке отобразить ошибку был передан не инициализированный объект");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"При работе программы возникло исключение: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string Read()
        {
            Console.Write("You->");
            return Console.ReadLine();
        }

        public void Dispose() { }
    }
}
