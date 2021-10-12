using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    public class Controller
    {
        private static int _id = 0;
        private readonly Dictionary<int, Task> _list = new();

        public bool add(Task task)
        {
            try
            {
                task.id = _id++;
                _list.Add(task.id, task);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool update(Task task)
        {
            try
            {
                _list[task.id] = task;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Task> get()
        {
            return _list.Values.ToList();
        }

        public List<Task> filterPriority()
        {
            var sorted=  from entry in _list orderby entry.Value.priority ascending select entry;
            return sorted.ToDictionary(e=>e.Key,e=>e.Value).Values.ToList();
        }

        public List<Task> filterTime()
        {
            var sorted = from entry in _list where entry.Value.dueTime<=DateTime.Now orderby entry.Value.dueTime ascending select entry;
            return sorted.ToDictionary(e => e.Key, e => e.Value).Values.ToList();
        }

        public bool delete(Task task)
        {
            try
            {
                _list.Remove(task.id);
                return true; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void start()
        {
            this.add(new Task() { name = "Test1", priority = 5, dueTime = new DateTime(2021,10, DateTime.Now.Day-1)});
            this.add(new Task() { name = "Test2", priority = 2, dueTime = new DateTime(2021, 10, DateTime.Now.Day + 2) });
            this.add(new Task() { name = "Test3", priority = 7, dueTime = new DateTime(2021, 10, DateTime.Now.Day + 3) });
        }
    }
}
