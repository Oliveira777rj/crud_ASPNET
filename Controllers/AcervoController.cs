using acervoLivros.Data;
using acervoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace acervoLivros.Controllers
{
    public class AcervoController : Controller
    {
        private readonly AppDbContext _db;
        public AcervoController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<AcervoModel> livros = _db.Livros;
            return View(livros);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AcervoModel livro = _db.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AcervoModel livro = _db.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }


        [HttpPost]
        public IActionResult Register(AcervoModel livros)
        {
            if (ModelState.IsValid)
            {
                _db.Livros.Add(livros);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Edit(AcervoModel livro)
        {
            if (ModelState.IsValid)
            {
                _db.Livros.Update(livro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        [HttpPost]
        public IActionResult Delete(AcervoModel livro)
        {
            if (livro == null)
            {
                return NotFound();
            }

            _db.Livros.Remove(livro);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}