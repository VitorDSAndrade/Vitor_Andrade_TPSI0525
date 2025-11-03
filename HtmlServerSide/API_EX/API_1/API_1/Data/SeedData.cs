using System.Linq;
using sharp_01.Models;

namespace sharp_01.Data
{
    public static class SeedData
    {
        public static void EnsureSeeded(ApiContext db)
        {
            db.Database.EnsureCreated();

            if (!db.Students.Any())
            {
                db.Students.AddRange(
                    new Student { Name = "Alice", Age = 19, Course = "IT" },
                    new Student { Name = "Bob", Age = 21, Course = "Design" }
                );
            }

            if (!db.Products.Any())
            {
                db.Products.AddRange(
                    new Product { Name = "Mouse", Price = 15.99, Stock = 120 },
                    new Product { Name = "Keyboard", Price = 45.5, Stock = 75 }
                );
            }

            if (!db.Reservations.Any())
            {
                db.Reservations.AddRange(
                    new Reservation { Client = "John", Room = 202, Nights = 3 },
                    new Reservation { Client = "Sophie", Room = 101, Nights = 2 }
                );
            }

            if (!db.Books.Any())
            {
                db.Books.AddRange(
                    new Book { Title = "The Hobbit", Author = "Tolkien", Available = true },
                    new Book { Title = "1984", Author = "Orwell", Available = false } // bookId 2 is unavailable
                );
            }

            if (!db.Employees.Any())
            {
                db.Employees.AddRange(
                    new Employee { Name = "Karen", Role = "Manager", Salary = 3200 },
                    new Employee { Name = "Leo", Role = "Technician", Salary = 1800 }
                );
            }

            if (!db.Tasks.Any())
            {
                db.Tasks.AddRange(
                    new TaskItem { Title = "Prepare report", Completed = false },
                    new TaskItem { Title = "Clean workspace", Completed = true }
                );
            }

            if (!db.Customers.Any())
            {
                db.Customers.AddRange(
                    new Customer { Name = "Marta", Email = "marta@mail.com" },
                    new Customer { Name = "Daniel", Email = "daniel@mail.com" }
                );
            }

            db.SaveChanges();
        }
    }
}
