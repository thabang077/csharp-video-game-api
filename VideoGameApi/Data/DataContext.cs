using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                    : base(options) { }

        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(

                 new VideoGame
                 {
                     Id = 1,
                     Title = "The Legend of Zelda: Breath of the Wild",
                     Platform = "Nintendo Switch",
                     Developer = "Nintendo EPD",
                     Publisher = "Nintendo"
                 },
            new VideoGame
            {
                Id = 2,
                Title = "God of War",
                Platform = "PlayStation 4",
                Developer = "Santa Monica Studio",
                Publisher = "Sony Interactive Entertainment"
            },
            new VideoGame
            {
                Id = 3,
                Title = "Minecraft",
                Platform = "Multi-platform",
                Developer = "Mojang Studios",
                Publisher = "Mojang Studios"
            });

        }

    }  
}
