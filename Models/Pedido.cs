using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebPedido.Models
{
    public class Pedido
    {
        [Key]
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public List<ItemPedido> Itens { get; set; }
    }
}
