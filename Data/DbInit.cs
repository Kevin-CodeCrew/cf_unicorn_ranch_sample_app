using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnicornRanch.Models;

namespace UnicornRanch.Data
{
    public class DbInit
    {
        public void SeedUnicorns(UnicornFarmDbContext context)
        {
            if (!context.unicorns.Any())
            {
                var newUnicorns = new List<UnicornModel>
                {
                    new UnicornModel() { UnicornName = "Afghanistan",Color = "Brown",FavoriteSnack="Candy"},
                    new UnicornModel() { UnicornName = "Bob",Color = "Yellow",FavoriteSnack="Corn"},
                    new UnicornModel() { UnicornName = "Jane",Color = "White",FavoriteSnack="Other Unicorns"},
                };
                context.AddRange(newUnicorns);
                context.SaveChanges();
            }
        }
    }
}
