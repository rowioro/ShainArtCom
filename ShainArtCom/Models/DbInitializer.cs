using System.Linq;

namespace ShainArtCom.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Arts.Any())
            {
                context.AddRange(

                new Art { Title = "Zed - The Shadow", Artist = "Shain", Year = 2020, Subject = "Zed", Dimensions = "3200 x 2008", Description = "Fanart ulubionej postaci z gry League of Legends", Price = 9999, PictureUrl = "/images/zedTheShadow.png", PictureMinUrl = "/images/zedTheShadow.png", ArtOfWeek = false}
                );
            }
            context.SaveChanges();
        }
    }
}
