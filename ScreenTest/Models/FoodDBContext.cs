using Microsoft.EntityFrameworkCore;

namespace ScreenTest.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }        
    }

    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions options)
            : base(options)
        {
            //If model change, It will re-create new database.
            //Database.SetInitializer<personContext>(new DropCreateDatabaseIfModelChanges<personContext>());
        }
        public DbSet<Dish> Dishes { get; set; }
    }
}
