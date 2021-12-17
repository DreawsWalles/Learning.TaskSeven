using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.FakeRepository
{
    public class FakeDownloadWebSiteRepository : IRepository
    {
        public void Add(AskModel model)
        {
            throw new Exception("Данный метод не поддерживается в данной реализации репозитория");
        }
        public string Get(int id)
        {
            string tmp;
            using(StreamReader file = new StreamReader("downloadWebSite"))
            {
                tmp = file.ReadToEnd();
            }
            int indexBeg = tmp.IndexOf("<title");
            int indexEnd = tmp.IndexOf("</title>");
            return $"Содержимое тега <title>: {tmp.Substring(indexBeg + 7, indexEnd - indexBeg - 7)}";
        }
    }
}
