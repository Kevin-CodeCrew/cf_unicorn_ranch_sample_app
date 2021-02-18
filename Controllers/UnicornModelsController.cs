using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnicornRanch.Data;
using UnicornRanch.Models;

namespace UnicornRanch.Controllers
{
    public class UnicornModelsController : Controller
    {
        private readonly UnicornFarmDbContext _context;

        public UnicornModelsController(UnicornFarmDbContext context)
        {
            _context = context;
        }

        // GET: UnicornModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.unicorns
                .Include(u=>u.CurrentLocation).ToListAsync());
        }

        // GET: UnicornModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unicornModel = await _context.unicorns
                .Include(u => u.CurrentLocation)
                .FirstOrDefaultAsync(u => u.id == id);
            if (unicornModel == null)
            {
                return NotFound();
            }

            return View(unicornModel);
        }


        // Add seed data if needed when this endpoint gets hit
        // Will added canned unicorns and their associated locations
        public IActionResult SeedData()
        {
            string seedResponseMsg = "Database already has been seeded"; // Default response message

            // If there arent any unicorns seed the database
            if (!_context.unicorns.Any())
            {

                var newLocations = new List<UnicornLocationModel>
                {
                    new UnicornLocationModel() { id=1, LocationName = "Barn"},
                    new UnicornLocationModel() { id=2, LocationName = "Pasture"},
                    new UnicornLocationModel() { id=3, LocationName = "Magical Training Area 1"},
                    new UnicornLocationModel() { id=4, LocationName = "Combat Training Area 2"},
                    new UnicornLocationModel() { id=5, LocationName = "The Local Pub"}
                };
                _context.AddRange(newLocations); // add our possible unicorn locations
                // Save our locations 
                _context.SaveChanges();

                var newUnicorns = new List<UnicornModel>
                {
                    new UnicornModel() { id=1, UnicornName = "Afghanistan",Color = "Brown",FavoriteSnack="Candy",CurrentLocation=_context.locations.FirstOrDefault(location=>location.id==1)},
                    new UnicornModel() { id=2, UnicornName = "Bob",Color = "Yellow",FavoriteSnack="Corn", CurrentLocation=_context.locations.FirstOrDefault(location=>location.id==3)},
                    new UnicornModel() { id=3, UnicornName = "Jane",Color = "White",FavoriteSnack="Other Unicorns", CurrentLocation=_context.locations.FirstOrDefault(location=>location.id==5)},
                };
                _context.AddRange(newUnicorns); // add our unicorns
                // Save our unicorns
                _context.SaveChanges();
                seedResponseMsg = "Seeded the database with new Unicorns and Locations";
            }
            // Return simple result message
            return Content(seedResponseMsg);
        }
    }
}
