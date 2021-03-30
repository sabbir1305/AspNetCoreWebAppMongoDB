using CarGalleryApp.Models;
using CarGalleryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGalleryApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }
        // GET: CarsController
        public ActionResult Index()
        {
            return View(_service.Get());
        }

        // GET: CarsController/Details/5
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var car = _service.Get(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _service.Create(car);

                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var car = _service.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _service.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }

        // GET: CarsController/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var car = _service.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
          
        }

        // POST: CarsController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = _service.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _service.Remove(car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
