using DAL;
using System;
using System.Collections.Generic;
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
            
        }
        
        public void AddFilm(Film film)
        {
            bool t = _filmCtx.Database.Exists();
            Console.WriteLine("TEST" + t);
            _filmCtx.Films.Add(film);
            _filmCtx.SaveChanges();
        }

        public void AddCharacter(Character character)
        {
            _filmCtx.Characters.Add(character);
            _filmCtx.SaveChanges();
        }

        public void AddActor(Actor actor)
        {
            _filmCtx.Actors.Add(actor);
            _filmCtx.SaveChanges();
        }

        public void AddCharacterActors(Film film, Character character, Actor actor)
        {
            CharacterActors CA = new CharacterActors(film, character, actor);
            _filmCtx.CharacterActors.Add(CA);
            _filmCtx.SaveChanges();
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
