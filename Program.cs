using System.Net;
using System.Text;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HttpListener httpListner = new HttpListener();
            httpListner.Prefixes.Add("http://localhost:51370/");
            httpListner.Start();
            var context = httpListner.GetContext();

            var stream = context.Response.OutputStream;

            string text = "<form method = \"post\"> <input type=\"text\" /> </form>";
            var bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);

            context.Response.StatusCode = 301;
            context.Response.Close();
            httpListner.Stop();
            httpListner.Close();

            Console.WriteLine(HttpListener.IsSupported);
        }
    }

}
}