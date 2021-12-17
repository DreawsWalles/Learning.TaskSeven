using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Help;

namespace ViewLib
{

    public class ViewWeb : IView
    {
        HttpListener _server;
        HttpListenerContext _context;
        public ViewWeb(string prefix)
        {
            if(!HttpListener.IsSupported)
                throw new Exception("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
            if(prefix == null)
                throw new ArgumentException("prefixes");
            _server = new HttpListener();
            _server.Prefixes.Add(prefix);
            _server.Start();
            HtmlFile.Create();
        }

        public void Dispose()
        {
            _server.Stop();
            _server.Close();
        }

        public string Read()
        {
            _context = _server.GetContext();
            HttpListenerRequest request = _context.Request;
            string responseString;
            byte[] buffer;
            HttpListenerResponse response;
            if (request.HttpMethod == "POST")
            {
                if (!request.HasEntityBody)
                    return null;
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
                return text;
            }
            responseString = HtmlFile.Get();
            response = _context.Response;
            response.ContentType = "text/html; charset=UTF-8";
            buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
            return "get";
        }

        public void ViewAnswer(string question, string answer)
        {
            HtmlFile.PrintAnswer(question, answer);
            string responseString = HtmlFile.Get();
            HttpListenerResponse response = _context.Response;
            response.ContentType = "text/html; charset=UTF-8";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
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

        public void ViewHistory(List<HistoryModel> parametrs)
        {
            HtmlFile.PrintHistory(parametrs);
        }
    }
}
