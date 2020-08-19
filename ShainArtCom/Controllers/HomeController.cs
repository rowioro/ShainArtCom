using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using ShainArtCom.Models;
using ShainArtCom.ViewModels;
using System.Linq;

namespace ShainArtCom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtRepository _artRepository;

        public HomeController(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        public IActionResult Index()
        {
            var arts = _artRepository.GetArts().OrderBy(a => a.Title);

            var homeVM = new HomeViewModel()
            {
                Tytul = "View Arts",
                Arts = arts.ToList()
            };

            return View(homeVM);
        }

        public IActionResult Details(int id)
        {
            var art = _artRepository.GetArtId(id);

            if (art == null)
                return NotFound();

            return View(art);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
