using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DALTest;

namespace DAL
{
    class TodoCtx : DbContext
    {
        public TodoCtx() : base()
        {


        }

        public DbSet<Todo> TabTodos { get; set; }
    }
}
