using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALManager: IDisposable
    {
        private readonly FilmCtx _filmCtx;

        public DALManager(string connString)
        {
            
            _filmCtx = new FilmCtx(connString);
            if (!_filmCtx.Database.Exists())
                Console.WriteLine("Création de la base " + connString);
        }
        
        public void AddFilm(Film film)
        {
            //foreach (CharacterActors c in film.CharacterActors)
            //    this.AddCharacterActors(c);
            //foreach (Director d in film.Directors)
            //    this.AddDirector(d);

            foreach (Genre g in film.Genres)
                if (_filmCtx.Genre.Any(o => o.GenreId == g.GenreId))
                    _filmCtx.Genre.Attach(g);


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

            // BUG SINCE ADDED Film TO COLLECTION IN Rating, Status, Director, etc
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
            //if (!_filmCtx.Actors.Any(o => o.ActorId == ca.ActorId))
            //    this.AddActor(ca.Actor);
            //if (!_filmCtx.Characters.Any(o => o.CharacterId == ca.CharacterId))
            //    this.AddCharacter(ca.Character);

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
            if(_filmCtx.Genre.Any(o => o.GenreId == genre.GenreId))
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
            if(comment.Rate > 5 || comment.Rate < 0)
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
