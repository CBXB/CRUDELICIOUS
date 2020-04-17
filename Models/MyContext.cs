using Microsoft.EntityFrameworkCore;



namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // this is the variable we will use to connect to the MySQL table, Lizards
        public DbSet<Dish> Dishess { get; set; }

    }
}