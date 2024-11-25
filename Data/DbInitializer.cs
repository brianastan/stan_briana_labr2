using Microsoft.EntityFrameworkCore;
using stan_briana_labr2.Models;

namespace stan_briana_labr2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                // Adăugarea autorilor
                var authors = new Authors[]
                {
                    new Authors { FirstName = "Mihail", LastName = "Sadoveanu" },
                    new Authors { FirstName = "George", LastName = "Calinescu" },
                    new Authors { FirstName = "Mircea", LastName = "Eliade" }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();

                // Adăugarea cărților cu referințe către autorii existenți
                var books = new Book[]
                {
                    new Book { Title = "Baltagul", AuthorID = authors.Single(a => a.LastName == "Sadoveanu").ID, Price = Decimal.Parse("22") },
                    new Book { Title = "Enigma Otiliei", AuthorID = authors.Single(a => a.LastName == "Calinescu").ID, Price = Decimal.Parse("18") },
                    new Book { Title = "Maytrei", AuthorID = authors.Single(a => a.LastName == "Eliade").ID, Price = Decimal.Parse("27") }
                };
                context.Book.AddRange(books);

                // Adăugarea genurilor
                context.Genre.AddRange(
                    new Genre { Name = "Roman" },
                    new Genre { Name = "Nuvela" },
                    new Genre { Name = "Poezie" }
                );

                // Adăugarea clienților
                context.Customer.AddRange(
                    new Customer { Name = "Popescu Marcela", Adress = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Adress = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                );

                // Salvarea modificărilor în baza de date
                context.SaveChanges();
            }
        }
    }
}
