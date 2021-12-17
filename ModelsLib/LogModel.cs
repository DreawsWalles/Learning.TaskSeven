using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    [Serializable]
    public class LogModel
    {
        public int Id { get; set; }
        public string ErrorText { get; set; }
        public DateTime Date { get; set; }
    }
}
