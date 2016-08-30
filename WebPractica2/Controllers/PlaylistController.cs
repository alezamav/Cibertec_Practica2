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
    public class PlaylistController : BaseController<Playlist>
    {
        // GET: Playlist
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.PlaylistId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            if (!ModelState.IsValid) return View(playlist);
            _repository.Add(playlist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }

        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            if (!ModelState.IsValid) return View(playlist);
            _repository.Update(playlist);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }

        [HttpPost]
        public ActionResult Delete(Playlist playlist)
        {
            _repository.Delete(playlist);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var playlist = _repository.GetById(x => x.PlaylistId == id);
            if (playlist == null) return RedirectToAction("Index");
            return View(playlist);
        }
    }
}