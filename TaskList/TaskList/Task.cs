using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    public class Task
    {
        public int id { get; set; }

        public string name { get; set; }

        public int priority { get; set; }

        public DateTime dueTime { get; set; }

        public override string ToString()
        {
            return id+" "+name+ " "+priority+" "+dueTime;
        }
    }
}
