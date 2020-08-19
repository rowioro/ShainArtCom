using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShainArtCom.Models
{
    public interface IArtRepository
    {
        IEnumerable<Art> GetArts();
        Art GetArtId(int artId);
    }
}
