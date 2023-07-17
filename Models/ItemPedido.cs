using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPedido.Models
{
    public class ItemPedido
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{N2}")]
        public decimal PrecoUnitario { get; set; }
    }
}
