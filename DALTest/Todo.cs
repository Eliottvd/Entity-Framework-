using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }

        public Todo()
        {
        }

        public Todo(string name, bool done)
        {
            Name = name;
            Done = done;
        }

        public Todo(string name)
        {
            Name = name;
            Done = false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
