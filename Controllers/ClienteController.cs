using WebPedido.Context;
using WebPedido.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebPedido.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PedidoContext _context;

        public ClienteController(PedidoContext context) => _context = context;
        public IActionResult Index()
        {
            var funcionarios = _context.Clientes.ToList();


            return View(funcionarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(cliente);
        }

        public IActionResult Detalhes(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }


        public IActionResult Editar(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            var Banco = _context.Clientes.Find(cliente.ID);

            Banco.Nome = cliente.Nome;
            Banco.Endereco = cliente.Endereco;
            Banco.Telefone = cliente.Telefone;
           
  

            _context.Clientes.Update(Banco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            var contato = _context.Clientes.Find(id);

            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);

        }

        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            var Banco = _context.Clientes.Find(cliente.ID);

            _context.Clientes.Remove(Banco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult PesquisaNome(string nome)
        {

            var tarefas = _context.Clientes.Where(x => x.Nome.Contains(nome)).ToList();

            return View(tarefas);
        }



    }
}
