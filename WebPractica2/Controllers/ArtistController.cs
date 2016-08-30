using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPractica2.Filters;
using WebPractica2.Model;
using WebPractica2.Repository;


namespace WebPractica2.Controllers
{
    public class ArtistController : BaseController<Artist>
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.ArtistId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Add(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var address = _repository.GetById(x => x.ArtistId == id);
            if (address == null) return RedirectToAction("Index");
            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Update(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var address = _repository.GetById(x => x.ArtistId == id);
            if (address == null) return RedirectToAction("Index");
            return View(address);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            _repository.Delete(artist);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var address = _repository.GetById(x => x.ArtistId == id);
            if (address == null) return RedirectToAction("Index");
            return View(address);
        }


    }
}