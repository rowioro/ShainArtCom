using System.Collections.Generic;

namespace ShainArtCom.Models
{
    public class Art
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Subject { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string PictureMinUrl { get; set; }
        public bool ArtOfWeek { get; set; }


        public virtual ICollection<Comment> GetComments { get; set; }
    }
}
