using System.Collections.Generic;
using System.Linq;

namespace ShainArtCom.Models
{
    public class MockArtRepository : IArtRepository
    {
        private List<Art> arts;
        public MockArtRepository()
        {
            if (arts == null)
            {
                LoadArts();
            }
        }

        private void LoadArts()
        {
            arts = new List<Art>
            {
                new Art { Id = 1, Title = "Zed - The Shadow", Artist = "Shain", Year = 2020, Subject = "Zed", Dimensions = "3200 x 2008", Description = "Fanart ulubionej postaci z gry League of Legends", Price = 9999, PictureUrl = "/images/zedTheShadow.png", PictureMinUrl = "/images/zedTheShadow.png", ArtOfWeek = false}
            };
        }

        public Art GetArtId(int IdArt)
        {
            return arts.FirstOrDefault(a => a.Id == IdArt);
        }

        public IEnumerable<Art> GetArts()
        {
            return arts;
        }
    }
}
