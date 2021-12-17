using ModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    public interface IView : IDisposable
    {
        void ViewAnswer(string question, string answer);
        void ViewHistory(List<HistoryModel> parametrs);
        void ViewError(string message);
        string Read();
        
    }
}
