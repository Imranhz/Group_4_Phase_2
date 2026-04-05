using Group4Flight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group4Flight.Areas.Airline.Controllers
{
    [Area("Airline")]
    public class HomeController : Controller
    {
        private readonly FlightContext _context;

        public HomeController(FlightContext context)
        {
            _context = context;
        }

        // GET: /Airline/Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            var flights = _context.Flights.Include(f => f.Airline)
                                          .OrderBy(f => f.Date)
                                          .ToList()
                                          .OrderBy(f => f.Date).ThenBy(f => f.DepartureTime)
                                          .ToList();
            return View(flights);
        }

        // GET: /Airline/Home/Add
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new FlightViewModel
            {
                Airlines = _context.Airlines.ToList()
            };
            return View(vm);
        }

        // POST: /Airline/Home/Add (PRG)
        [HttpPost]
        public IActionResult Add(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flights.Add(flight);
                _context.SaveChanges();
                TempData["Message"] = $"Flight {flight.FlightCode} added successfully!";
                return RedirectToAction(nameof(Index));
            }

            var vm = new FlightViewModel
            {
                Airlines = _context.Airlines.ToList()
            };
            return View(vm);
        }

        // GET: /Airline/Home/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null) return NotFound();

            ViewBag.Airlines = _context.Airlines.ToList();
            return View(flight);
        }

        // POST: /Airline/Home/Edit (PRG)
        [HttpPost]
        public IActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flights.Update(flight);
                _context.SaveChanges();
                TempData["Message"] = $"Flight {flight.FlightCode} updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Airlines = _context.Airlines.ToList();
            return View(flight);
        }

        // POST: /Airline/Home/Delete (PRG)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
                TempData["Message"] = $"Flight {flight.FlightCode} deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
