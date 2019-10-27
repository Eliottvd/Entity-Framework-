using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace DAL
{
    public class FilmCtx : DbContext
    {
        public FilmCtx() : base("db_films")
        {


        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterActors> CharacterActors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
