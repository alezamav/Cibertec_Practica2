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
    public class CustomerController : BaseController<Customer>
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.CustomerId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            _repository.Delete(customer);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }
    }
}