using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieBillboard.Models;

namespace MovieBillboard.Data
{
    public class MovieContext : IdentityDbContext<IdentityUser>
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<MovieBillboard.Models.Movie> Movie { get; set; } = default!;
        // public DbSet<MovieBillboard.Models.Rating> Rating { get; set; } = default!;
    }
}
