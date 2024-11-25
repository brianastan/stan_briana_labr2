using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stan_briana_labr2.Models;

namespace stan_briana_labr2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<stan_briana_labr2.Models.Book> Book { get; set; } = default!;

        public DbSet<stan_briana_labr2.Models.Customer> Customer { get; set; } = default!;
        public DbSet<stan_briana_labr2.Models.Genre> Genre { get; set; } = default!;
        public DbSet<stan_briana_labr2.Models.Authors> Authors { get; set; } = default!;

    }

}

