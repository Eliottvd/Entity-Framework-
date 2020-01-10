using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using WebApp.ServiceReference1;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {
        private int pageSize = 10;
        private Service1Client serv = new Service1Client();
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Actors(string actName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(actName, 0, pageSize);
            listActors tmp = new listActors(actorDTOs);
            ViewBag.PartialName = actName; 
            ViewBag.nbPageActors = 0;

            return View(tmp);
        }

        public ActionResult Next(string actName, int nbPageActors)
        {
            nbPageActors++;
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(actName, nbPageActors, pageSize);
            listActors tmp = new listActors(actorDTOs);
            ViewBag.PartialName = actName;
            ViewBag.nbPageActors = nbPageActors;

            return View("Actors", tmp);
        }

        public ActionResult Previous(string actName, int nbPageActors)
        {
            nbPageActors = nbPageActors > 0 ? --nbPageActors: nbPageActors;
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(actName, nbPageActors, pageSize);
            listActors tmp = new listActors(actorDTOs);
            ViewBag.PartialName = actName;
            ViewBag.nbPageActors = nbPageActors;

            return View("Actors", tmp);
        }

        public ActionResult Details(string fullActName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(fullActName, 0,10);
            ActorDTO act = actorDTOs.First();
            List<FilmDTO> filmDTOs = serv.GetListFilmsByIdActor(act.ActorId);
            FilmDTO tmp = filmDTOs.First();
            WebApp.Models.Movie MovModel = new Models.Movie(tmp);

            return View(MovModel);
        }

        public ActionResult Movies(string fullActName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(fullActName, 0, 10);
            ActorDTO act = actorDTOs.First();
            List<FilmDTO> filmDTOs = serv.GetListFilmsByIdActor(act.ActorId);
            WebApp.Models.listMovies MovModel = new listMovies(filmDTOs);
            return View(MovModel);
        }

        public ActionResult Comments(string fullActName)
        {
            ViewBag.ActName = fullActName; 
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(fullActName, 0, 10);
            ActorDTO act = actorDTOs.First();
            FullActorDTO fullAct = serv.GetFullActorDetailsByIdActor(act.ActorId);
            listComments Comments = new listComments(fullAct.Comments);
            ViewBag.ActorId = act.ActorId;
            ViewBag.ActorName = act.Name;

            return View(Comments);
        }

        public ActionResult AddComment(int ActorId, string avatar, string content, string rate)
        {

            serv.InsertCommentOnActorId(new CommentDTO()
            {
                Avatar = avatar,
                Content = content,
                Rate = float.Parse(rate),
                Date = DateTime.Now,
                
            }, ActorId);

            return View();
        }
    }
}