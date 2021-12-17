using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib
{
    public class NoCommand : ICommand
    {
        public string Execute()
        {
            return null;
        }
    }
}
