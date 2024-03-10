using Microsoft.EntityFrameworkCore;
using WegGridCore.Models;


namespace WegGridCore.EF
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
                
        }

        public DbSet<HeightFenceModel> HeightFence { get; set; }
        public DbSet<ColorFenceModel> ColorFence { get; set; }
        public DbSet<OrderModel> Order { get; set; }
    }
}
