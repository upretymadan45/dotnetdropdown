using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dropdown.Models;
using dropdown.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();
            ViewBag.Countries = new SelectList(countries,"Id","Name");
            return View();
        }

        public IActionResult GetStatesFromCountry(int id){
            var states = _context.States.Where(x=>x.CountryId == id).ToList();
            return Ok(states);
        }

        public IActionResult GetVillagesFromState(int id){
            var villages = _context.Villages.Where(x=>x.StateId == id).ToList();
            return Ok(villages);
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
