using Microsoft.EntityFrameworkCore;
using sharp_01.Models;
using System.Collections.Generic;


namespace sharp_01.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<StandCars> StandCar { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){}
    }
}