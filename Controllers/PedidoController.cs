using WebPedido.Context;
using WebPedido.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebPedido.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoContext _context;

        public PedidoController(PedidoContext context) => _context = context;

        
        public IActionResult Index()
        {
            var pedidos = _context.Pedidos.Include(p => p.Cliente).ToList();


            return View(pedidos);
        }

        public IActionResult Detalhes(int id)
        
       {
            var pedido = _context.Pedidos.Include(p => p.Cliente).Include(p => p.Itens).ThenInclude(i => i.Produto).FirstOrDefault(p => p.ID == id);

            if (pedido == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }
    }
}
