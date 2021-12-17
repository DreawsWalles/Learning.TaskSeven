using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLib;
using CommandLib.Aphorisms;
using CommandLib.Hello;
using CommandLib.MyName;
using CommandLib.Time;
using CommandLib.Joke;
using CommandLib.Bye;
using CommandLib.Help;
using CommandLib.Logger;
using CommandLib.DownloadWebSite;
using RepositoryLib;
using ViewLib;
using HistoryLib;
using ModelsLib;

namespace ReceiverLib
{
    public class ChatBot : IDisposable
    {
        private static UnitOfWork _unit;
        private History _history;
        private Dictionary<string, ICommand> _tasks;
        private Thread _thread;
        private Queue<string> _questionsQueue;
        private IView _view;

        public ChatBot(History history, UnitOfWork work, IView view )
        {
            if (history == null || work == null || view == null)
                throw new Exception("При инициализации \"ChatBot\" были переданы не инициализированные объекты");
            _unit = work;
            _history = history;
            _tasks = new Dictionary<string, ICommand>()
            {
                {"доброе утро", new HelloCommand(new HelloPhrase()) },
                {"добрый день", new HelloCommand(new HelloPhrase()) },
                {"добрый вечер", new HelloCommand(new HelloPhrase()) },
                {"доброй ночи", new HelloCommand(new HelloPhrase()) },
                {"привет", new HelloCommand(new HelloPhrase()) },
                {"здравствуй", new HelloCommand(new HelloPhrase()) },
                {"здравствуйте", new HelloCommand(new HelloPhrase()) },
                {"как тебя зовут?", new MyNameCommand(new MyNamePhrase(_unit.NyName)) },
                {"сколько времени?", new TimeCommand(new TimePhrase()) },
                {"анекдот", new JokeCommand(new JokePhrase(_unit.Joke)) },
                {"пока", new ByeCommad(new BuyPhrase(_unit.Bye)) },
                {"до свидания", new ByeCommad(new BuyPhrase(_unit.Bye)) },
                {"-help", new HelpCommand(new HelpPhrase(_unit.Help)) },
                {"logs", new  LoggerCommand(new LoggerPhrase())}
            };
            _view = view;
            _thread = new Thread(new ThreadStart(Check));
            _questionsQueue = new Queue<string>();
            _history.DownLoad();
            _thread.Start();
        }
        public void Begin()
        {
            string task = "";
            while (true)
            {
                task = _view.Read();
                Ask(task);
            }
        }
        private void Check()
        {
            while(true)
            {
                if (_questionsQueue.Any())
                {
                    string question = _questionsQueue.Dequeue();
                    Task task = new Task(new Action(() => { Answer(question); }));
                    task.Start();
                    task.Wait();
                }
            }
        }
        private async void Answer(string question)
        {
            if (question == "get")
                return;
            if (question == null)
                throw new ArgumentNullException(nameof(question));
            string answer;
            try
            {
                HttpClient client = new HttpClient();
                using (HttpResponseMessage response = client.GetAsync(question).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        using (StreamWriter file = new StreamWriter("downloadWebSite"))
                        {
                            await file.WriteLineAsync(result);
                        }
                        answer = new DownloadWebSiteCommand(new DownloadWebSitePhrase(_unit.DownLoadWebSite)).Execute();
                        _history.Add(new HistoryModel() { Id = 0, dateTime = DateTime.Now, BotMessage = answer, Question = question });
                        _view.ViewAnswer(question, answer);
                        File.Delete("downloadWebSite");
                        return;
                    }
                }
            }
            catch { }
            if (_tasks.ContainsKey(question.ToLower()))
                answer = _tasks[question.ToLower()].Execute();
            else
                answer = new AphorismsCommand(new AphorismsPhrase(_unit.Aphorisms)).Execute();
            if (answer == null)
                throw new Exception("Бот не смог найти ответ на ваш вопрос");
            _history.Add(new HistoryModel() { Id = 0, dateTime = DateTime.Now, BotMessage = answer, Question = question });
            _view.ViewAnswer(question, answer);
        }
        public void Ask(string question)
        {
            if (question == null)
                throw new Exception("При попытке получения ответа на запрос был передан не инициализированный объект");
            _questionsQueue.Enqueue(question);
        }

        public void Dispose()
        {
            File.Delete("XMLRepository/Aphorisms");
            File.Delete("XMLRepository/Bye");
            File.Delete("XMLRepository/Joke");
            File.Delete("XMLRepository/MyName");
            File.Delete("XMLRepository/Help");
            Directory.Delete("XMLRepository");
            File.Delete("JSONRepository/MyName");
            File.Delete("JSONRepository/Joke");
            File.Delete("JSONRepository/Bye");
            File.Delete("JSONRepository/Aphorisms");
            File.Delete("JSONRepository/Help");
            Directory.Delete("JSONRepository");
        }
    }
}
