using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShainArtCom.Models;
using System.Threading.Tasks;

namespace ShainArtCom.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(ICommentRepository commentRepository, AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewData["ArtId"] = new SelectList(_appDbContext.Arts, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Comment opinia)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                opinia.UserId = user.Id;
                _commentRepository.DodajOpinie(opinia);
                return RedirectToAction("CommentSended");
            }
            ViewData["ArtId"] = new SelectList(_appDbContext.Arts, "Id", "Title");
            return View(opinia);
        }

        public IActionResult CommentSended()
        {
            return View();
        }
    }
}
