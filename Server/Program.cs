using HistoryLib;
using ReceiverLib;
using RepositoryLib;
using RepositoryLib.FakeRepository;
using RepositoryLib.JSONRepository;
using RepositoryLib.XMLRepository;
using System.Net;
using System.Text;
using ViewLib;

namespace Server
{
    public class Program
    {
        private static bool isListen = true;
        public static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            if (!HttpListener.IsSupported)
                return;
            server.Prefixes.Add("http://localhost:51370/");
            server.Start();
            while(true)
            {
                IAsyncResult result =  server.BeginGetContext(new AsyncCallback(ListnerCallback), server);
                result.AsyncWaitHandle.WaitOne();
                if (!isListen)
                    return;
            }
        }
        private static void ListnerCallback(IAsyncResult result)
        {
            HttpListener server = (HttpListener)result.AsyncState;
            HttpListenerContext context = server.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            IView view = new ViewWeb(context);
            ChatBot bot = new ChatBot(new History(view), new UnitOfWork(new XMLAphorismsRepository(), new JSONMyNameRepository(), new XMLJokeRepository(), new XMLByeRepository(), new FakeHelpRepository(), new FakeDownloadWebSiteRepository()), view);
            if(request.HttpMethod == "POST")
            {
                if (!request.HasEntityBody)
                    return;
                string text;
                using (Stream body = request.InputStream)
                {
                    using (StreamReader reader = new StreamReader(body))
                    {
                        text = reader.ReadToEnd();
                        text = text.Remove(0, 7);
                        text = System.Web.HttpUtility.UrlDecode(text, Encoding.UTF8);
                    }
                }
                bot.Ask(text);
                if(text.ToLower() == "пока" || text.ToLower() == "до свидания")
                    isListen = false;
            }
            string responseString = @"<!DOCTYPE HTML>
                                        <html><head></head><body>
                                        <form method=""post"" action=""say"">
                                        <p><b>Name: </b><br>
                                        <input type=""text"" name=""myname"" size=""40""></p>
                                        <p><input type=""submit"" value=""send""></p>
                                        </form></body></html>";
            HttpListenerResponse response = context.Response;
            response.ContentType = "text/html; charset=UTF-8";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}