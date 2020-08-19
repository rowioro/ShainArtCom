using System.Collections.Generic;
using System.Linq;

namespace ShainArtCom.Models
{
    public class ArtRepository : IArtRepository
    {
        private readonly AppDbContext _appDbContext;

        public ArtRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Art GetArtId(int IdArt)
        {
            return _appDbContext.Arts.FirstOrDefault(a => a.Id == IdArt);
        }

        public IEnumerable<Art> GetArts()
        {
            return _appDbContext.Arts;
        }
    }
}
