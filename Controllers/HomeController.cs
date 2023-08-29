using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Data_business_layer;
using Attribute_layer;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClsPateint oClsPateint;

        IPateint _IPateint;

        public HomeController(ILogger<HomeController> logger, IPateint iPateint)
        {
            _logger = logger;
            oClsPateint = new ClsPateint();
            _IPateint = iPateint;
        }

        public IActionResult Index()
        {
            var data = _IPateint.GetAll();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = _IPateint.GetById(id);
            return View(data);
        }

        public IActionResult Delete1(int id)
        {
          

            _IPateint.Delete( id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid) 
            {
               return View("Edit",patient);
            }


            _IPateint.AddOrUpdate(patient);
         

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}