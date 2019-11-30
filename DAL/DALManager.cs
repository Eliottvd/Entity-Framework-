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
                
                if (_filmCtx.Characters.Any(o => o.CharacterName == ca.Character.CharacterName))
                {
                    ca.Character = _filmCtx.Characters.First(o => o.CharacterName == ca.Character.CharacterName);
                    ca.CharacterId = ca.Character.CharacterId;
                    // ATTACH BUG

                    _filmCtx.Characters.Attach(ca.Character);

                }
            }

            foreach (Genre g in film.Genres)
                if (_filmCtx.Genre.Any(o => o.GenreId == g.GenreId))
                {
                    _filmCtx.Genre.Attach(g);
                    g.Film.Add(film);
                }

            foreach (Director d in film.Directors)
                if (_filmCtx.Directors.Any(o => o.DirectorId == d.DirectorId))
                {
                    _filmCtx.Directors.Attach(d);
                    d.Film.Add(film);
                }

            if (_filmCtx.Rating.Any(o => o.Type == film.Rating.Type))
            {
                film.Rating = _filmCtx.Rating.First(o => o.Type == film.Rating.Type);
                _filmCtx.Rating.Attach(film.Rating);
            }

            if (_filmCtx.Status.Any(o => o.StatusName == film.Status.StatusName))
            {
                film.Status = _filmCtx.Status.First(o => o.StatusName == film.Status.StatusName);
                _filmCtx.Status.Attach(film.Status);
            }

            _filmCtx.Films.Add(film);

            _filmCtx.SaveChanges();
        }

        public void AddCharacter(Character character)
        {
            if (!_filmCtx.Characters.Any(o => o.CharacterId == character.CharacterId))
            {
                _filmCtx.Characters.Add(character);
                _filmCtx.SaveChanges();
            }
        }

        public void AddActor(Actor actor)
        {
            if (!_filmCtx.Actors.Any(o => o.ActorId == actor.ActorId))
            {
                _filmCtx.Actors.Add(actor);
                _filmCtx.SaveChanges();
            }
        }

        public void AddCharacterActors(CharacterActors ca)
        {
            _filmCtx.CharacterActors.Add(ca);
            _filmCtx.SaveChanges();
        }

        public void AddDirector(Director director)
        {
            if (!_filmCtx.Directors.Any(o => o.DirectorId == director.DirectorId))
            {
                _filmCtx.Directors.Add(director);
                _filmCtx.SaveChanges();
            }

        }

        public void AddGenre(Genre genre)
        {
            if (_filmCtx.Genre.Any(o => o.GenreId == genre.GenreId))
            {
                Console.WriteLine("Exists !");
            }
            else
            {
                Console.WriteLine("Doesnt Exists !");
                _filmCtx.Genre.Add(genre);
                _filmCtx.SaveChanges();
            }

        }

        public void AddComment(Comment comment)
        {
            if (comment.Rate > 5 || comment.Rate < 0)
            {

            }
            else
            {
                _filmCtx.Comments.Add(comment);
                _filmCtx.SaveChanges();
            }
        }

        public void Dispose()
        {
            _filmCtx.Dispose();
        }
    }
}
