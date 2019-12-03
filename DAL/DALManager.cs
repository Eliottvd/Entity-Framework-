using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALManager : IDisposable
    {
        private readonly FilmCtx _filmCtx;

        public FilmCtx FilmCtx => _filmCtx;

        public DALManager(string connString)
        {
            _filmCtx = new FilmCtx(connString);
            if (!_filmCtx.Database.Exists())
                Console.WriteLine("Création de la base " + connString);
        }

        public DALManager(FilmCtx filmCtx)
        {
            _filmCtx = filmCtx;
            if (!_filmCtx.Database.Exists())
                Console.WriteLine("Création de la base ");
        }

        public void AddFilm(Film film)
        {

            foreach (CharacterActors ca in film.CharacterActors)
            {
                
                if (FilmCtx.Characters.Any(o => o.CharacterName == ca.Character.CharacterName))
                {
                    ca.Character = FilmCtx.Characters.First(o => o.CharacterName == ca.Character.CharacterName);
                    ca.CharacterId = ca.Character.CharacterId;
                    // ATTACH BUG

                    FilmCtx.Characters.Attach(ca.Character);

                }
            }

            foreach (Genre g in film.Genres)
                if (FilmCtx.Genre.Any(o => o.GenreId == g.GenreId))
                {
                    FilmCtx.Genre.Attach(g);
                    g.Film.Add(film);
                }

            foreach (Director d in film.Directors)
                if (FilmCtx.Directors.Any(o => o.DirectorId == d.DirectorId))
                {
                    FilmCtx.Directors.Attach(d);
                    d.Film.Add(film);
                }

            if (FilmCtx.Rating.Any(o => o.Type == film.Rating.Type))
            {
                film.Rating = FilmCtx.Rating.First(o => o.Type == film.Rating.Type);
                FilmCtx.Rating.Attach(film.Rating);
            }

            if (FilmCtx.Status.Any(o => o.StatusName == film.Status.StatusName))
            {
                film.Status = FilmCtx.Status.First(o => o.StatusName == film.Status.StatusName);
                FilmCtx.Status.Attach(film.Status);
            }

            FilmCtx.Films.Add(film);

            FilmCtx.SaveChanges();
        }

        public void AddCharacter(Character character)
        {
            if (!FilmCtx.Characters.Any(o => o.CharacterId == character.CharacterId))
            {
                FilmCtx.Characters.Add(character);
                FilmCtx.SaveChanges();
            }
        }

        public void AddActor(Actor actor)
        {
            if (!FilmCtx.Actors.Any(o => o.ActorId == actor.ActorId))
            {
                FilmCtx.Actors.Add(actor);
                FilmCtx.SaveChanges();
            }
        }

        public void AddCharacterActors(CharacterActors ca)
        {
            FilmCtx.CharacterActors.Add(ca);
            FilmCtx.SaveChanges();
        }

        public void AddDirector(Director director)
        {
            if (!FilmCtx.Directors.Any(o => o.DirectorId == director.DirectorId))
            {
                FilmCtx.Directors.Add(director);
                FilmCtx.SaveChanges();
            }

        }

        public void AddGenre(Genre genre)
        {
            if (FilmCtx.Genre.Any(o => o.GenreId == genre.GenreId))
            {
                Console.WriteLine("Exists !");
            }
            else
            {
                Console.WriteLine("Doesnt Exists !");
                FilmCtx.Genre.Add(genre);
                FilmCtx.SaveChanges();
            }

        }

        public void AddComment(Comment comment)
        {
            if (comment.Rate > 5 || comment.Rate < 0)
            {

            }
            else
            {
                FilmCtx.Comments.Add(comment);
                FilmCtx.SaveChanges();
            }
        }

        public List<Film> getAllMovies()
        {
            return FilmCtx.Films.ToList();
        }

        public List<Actor> getActor()
        {
            return FilmCtx.Actors.ToList();
        }

        public List<CharacterActors> getCharacterActor()
        {
            return FilmCtx.CharacterActors.ToList();
        }

        public void Dispose()
        {
            FilmCtx.Dispose();
        }
    }
}
