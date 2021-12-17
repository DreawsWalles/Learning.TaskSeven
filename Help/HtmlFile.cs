using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class HtmlFile
    {

        public static void Create()
        {
            if (!Directory.Exists("Html"))
                Directory.CreateDirectory("Html");
            if (File.Exists("Html/MainPage.html"))
                File.Delete("Html/MainPage.html");
            FileStream fileStream = new FileStream("Html/MainPage.html", FileMode.CreateNew);
            using (StreamWriter file = new StreamWriter(fileStream))
            {
                file.WriteLine("﻿<!DOCTYPE html>");
                file.WriteLine("<html>");
                file.WriteLine("<head>");
                file.WriteLine("<meta charset=\"utf - 8\">");
                file.WriteLine("<title>HttpChat</title>");
                file.WriteLine("<link href=\"style.css\" rel=\"stylesheet\" type=\"text/css\">");
                file.WriteLine("<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">");
                file.WriteLine("</head>");
                file.WriteLine("<body>");

                file.WriteLine("<style>");
                file.WriteLine("body{");
                file.WriteLine("background-color: darkslategrey;");
                file.WriteLine("}");
                file.WriteLine(".content{");
                file.WriteLine("background-color: darkslategrey;");
                file.WriteLine("height: 100vh;");
                file.WriteLine("color:white;");
                file.WriteLine("padding-top: 4vh;");
                file.WriteLine("width: 95vw;");
                file.WriteLine("margin: 0 auto;");
                file.WriteLine("}");
                file.WriteLine(".message{");
                file.WriteLine("display: block;");
                file.WriteLine("background-color: darkcyan;");
                file.WriteLine("margin-bottom: 3vh;");
                file.WriteLine("width: 50vw;");
                file.WriteLine("padding-left: 2vw;");
                file.WriteLine("border-radius: 12px;");
                file.WriteLine("margin-left: 12vw;");
                file.WriteLine("padding-top: 1vh;");
                file.WriteLine("padding-bottom: 1vh;");
                file.WriteLine("margin-right: 12vw;");
                file.WriteLine("}");
                file.WriteLine(".message span{");
                file.WriteLine("display: flex;");
                file.WriteLine("}");
                file.WriteLine(".question{");
                file.WriteLine("margin-left: auto;");
                file.WriteLine("background-color: blueviolet;");
                file.WriteLine("}");
                file.WriteLine(".input{");
                file.WriteLine("padding-top: 5vh;");
                file.WriteLine("padding-bottom: 2vh;");
                file.WriteLine("left: 27vw;");
                file.WriteLine("width: 50vw;");
                file.WriteLine("margin: 0 auto;");
                file.WriteLine("}");
                file.WriteLine("</style>");

                file.WriteLine("<div class=\"content\">");

                file.WriteLine("<div class=\"history\">");
                file.WriteLine("<!--History-->");
                file.WriteLine("</div>");


                file.WriteLine("<div class=\"messages\">");
                file.WriteLine("<!--Message-->");
                file.WriteLine("</div>");


                file.WriteLine("<div class=\"input\">");
                file.WriteLine("<form method=\"post\" action=\"say\">");
                file.WriteLine("<div class=\"input-group mb-3\">");
                file.WriteLine("<span class=\"input-group-text\" id=\"basic-addon3\">You-></span>");
                file.WriteLine("<input type=\"text\" name=\"myname\" class=\"form-control\" id=\"basic - url\" aria-describedby=\"basic-addon3\">");
                file.WriteLine("<button type=\"submit\" class=\"btn btn-success\">Отправить</button>");
                file.WriteLine("</div>");
                file.WriteLine("</form>");
                file.WriteLine("</div>");

                file.WriteLine("</div>");
                file.WriteLine("</body>");
                file.WriteLine("</html>");
            }
        }
        public static string Get()
        {
            string result;
            using (StreamReader file = new StreamReader("Html/MainPage.html"))
            {
                result = file.ReadToEnd();
            }
            return result;
        }
        public static void PrintHistory(List<HistoryModel> parametrs)
        {
            List<string> result = new List<string>();
            string[] tmp;
            using (StreamReader file = new StreamReader("Html/MainPage.html"))
            {
                tmp = file.ReadToEnd().Split('\n');
            }
            int i = 0;
            while (tmp[i] != "<!--History-->\r")
            {
                result.Add(tmp[i].Trim());
                i++;
            }
            result.Add(tmp[i].Trim());
            foreach (HistoryModel element in parametrs)
            {
                result.Add("<div class=\"message question\"");
                result.Add($"<span>{String.Format("{0:g}", element.dateTime)}</span>");
                result.Add($"<span>{element.Question}</span>");
                result.Add("</div>");
                result.Add("<div class=\"message answer\"");
                result.Add($"<span>{String.Format("{0:g}", element.dateTime)}</span>");
                result.Add($"<span>{element.BotMessage}</span>");
                result.Add("</div>");
            }
            for (int j = i; j < tmp.Length; j++)
                result.Add(tmp[j].Trim());
            using (StreamWriter file = new StreamWriter("Html/MainPage.html"))
            {
                foreach(string element in result)
                    file.WriteLine(element);
            }
        }
        public static void PrintAnswer(string question, string answer)
        {
            List<string> result = new List<string>();
            string[] tmp;
            using (StreamReader file = new StreamReader("Html/MainPage.html"))
            {
                tmp = file.ReadToEnd().Split('\n');
            }
            int i = 0;
            while (tmp[i] != "<!--Message-->\r")
            {
                result.Add(tmp[i].Trim());
                i++;
            }
            result.Add("<div class=\"message question\"");
            result.Add($"<span>{String.Format("{0:g}", DateTime.Now)}</span>");
            result.Add($"<span>{question}</span>");
            result.Add("</div>");
            result.Add("<div class=\"message answer\"");
            result.Add($"<span>{String.Format("{0:g}", DateTime.Now)}</span>");
            result.Add($"<span>{answer}</span>");
            result.Add("</div>");
            result.Add(tmp[i].Trim());
            for (int j = i; j < tmp.Length; j++)
                result.Add(tmp[j].Trim());
            using (StreamWriter file = new StreamWriter("Html/MainPage.html"))
            {
                foreach (string element in result)
                    file.WriteLine(element);
            }
        }
    }
}
