using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL
{
    public class FilmCtx : DbContext
    {
        public FilmCtx(string connString) : base(connString)
        {
            Database.SetInitializer<FilmCtx>(new DropCreateDatabaseAlways<FilmCtx>());

        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterActors> CharacterActors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
