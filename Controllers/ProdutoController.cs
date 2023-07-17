using WebPedido.Context;
using WebPedido.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebPedido.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly PedidoContext _context;

        public ProdutoController(PedidoContext context) => _context = context;
        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();


            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(produto);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }


        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var ProdutoBanco = _context.Produtos.Find(produto.ID);

            ProdutoBanco.Nome = produto.Nome;
            ProdutoBanco.Descricao = produto.Descricao;
            ProdutoBanco.Preco = produto.Preco;
           
  

            _context.Produtos.Update(ProdutoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var contato = _context.Produtos.Find(id);

            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);

        }

        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            var Banco = _context.Produtos.Find(cliente.ID);

            _context.Produtos.Remove(Banco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult PesquisaNome(string nome)
        {

            var tarefas = _context.Produtos.Where(x => x.Nome.Contains(nome)).ToList();

            return View(tarefas);
        }



    }
}
