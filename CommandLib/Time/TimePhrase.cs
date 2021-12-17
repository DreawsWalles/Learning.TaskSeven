using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib.Time
{
    public class TimePhrase
    {
        public string Say()
        {
            return String.Format("{0:t}", DateTime.Now);
        }
    }
}
