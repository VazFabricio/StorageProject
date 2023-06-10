using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Entidades;
using Storage.Models;

namespace Storage.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly Contexto db;

        public ProdutosController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: ProdutosController
        public ActionResult Index(string query, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(query) )
            {
                return View(db.PRODUTOS.ToList());
            }
            else if (tipoPesquisa == "Todos")
            {
                return View(db.PRODUTOS.Where(a => a.Nome.Contains(query) || a.Preco.Equals(query)));
            }
            else if(tipoPesquisa == "Nome")
            {
                return View(db.PRODUTOS.Where(a => a.Nome.Contains(query)));
            }
            else if (tipoPesquisa == "Preco")
            {
                int preco;
                if (int.TryParse(query, out preco))
                {
                    return View(db.PRODUTOS.Where(a => a.Preco.Equals(preco)));
                }
                else
                {
                    return View("Error");
                }
            }
            else 
            {
                return View(db.PRODUTOS.ToList());
            }
            
        }

        // GET: ProdutosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            ProdutosModel model = new ProdutosModel();
            model.ListaCategorias = db.CATEGORIA.ToList();
            return View(model);
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produtos collection)
        {
            try
            {
                db.PRODUTOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.PRODUTOS.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produtos collection)
        {
            try
            {
                db.PRODUTOS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(int id)

        {
            db.PRODUTOS.Remove(db.PRODUTOS.Where((a) => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
