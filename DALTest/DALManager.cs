using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class DALManager: IDisposable
    {
        private readonly TodoCtx _todoCtx;

        public DALManager()
        {
            _todoCtx = new TodoCtx(); 
        }

        public void AddTodo(Todo todo)
        {
            _todoCtx.TabTodos.Add(todo);
            _todoCtx.SaveChanges();

        }

        public void Dispose()
        {
            _todoCtx.Dispose();
        }
    }
}
