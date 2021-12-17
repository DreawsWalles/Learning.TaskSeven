using Help;
using HistoryLib;
using ReceiverLib;
using RepositoryLib.FakeRepository;
using RepositoryLib.JSONRepository;
using RepositoryLib.XMLRepository;
using LoggerLib;
using ViewLib;
using RepositoryLib;

namespace taskTwo
{
    public class Program
    {
        public static void Main()
        {
            IView view = null;
            Menu menu = new Menu("Выберите интерфейс для работы");
            menu.Add("Консоль");
            menu.Add("Браузер");
            menu.Add("Завершить работу программы", true);
            menu.Print();
            switch(menu.Choice())
            {
                case 2:
                    view = new ViewWeb("http://localhost:51370/MainPage/");
                    break;
                case 1:
                    view = new ViewConsole();
                    break;
                default:
                    return;
            }
            Console.Clear();
            Logger logger = new Logger();
            try
            {
                ChatBot bot = new ChatBot(new History(view), new UnitOfWork(new XMLAphorismsRepository(), new JSONMyNameRepository(), new XMLJokeRepository(), new XMLByeRepository(), new FakeHelpRepository(), new FakeDownloadWebSiteRepository()), view);
                bot.Begin();
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
                view.ViewError(e.Message);
            }
            finally
            {
                view.Dispose();
            }
        }
    }
}