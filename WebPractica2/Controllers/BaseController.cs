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
    [ExceptionControl]
    public class BaseController<T> : Controller where T : class
    {
        protected IRepository<T> _repository;
        public BaseController()
        {
            _repository = new BaseRepository<T>();
        }
    }
}