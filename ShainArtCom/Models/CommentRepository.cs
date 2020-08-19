namespace ShainArtCom.Models
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void DodajOpinie(Comment opinia)
        {
            _appDbContext.Comments.Add(opinia);
            _appDbContext.SaveChanges();
        }
    }
}
