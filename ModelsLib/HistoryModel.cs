using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class HistoryModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string BotMessage { get; set; }
        public string Question { get; set; }
    }
}
