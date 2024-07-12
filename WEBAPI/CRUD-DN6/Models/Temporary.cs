using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DN6.Models
{
    public class Cliente
    {
        [Key]
        public string Cpf { get; set; } 
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }

    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string Nome { get; set; }
        public decimal ValorBase { get; set; }  
    }
    public class Pedido
    {
        [Key]
        public int NumeroPedido { get; set; }
        public DateTime Data { get; set; }
        public string Cpf { get; set; }
        public virtual ICollection<ItemPedido> ItemsPedido { get; set; }
        public decimal ValorTotal() {
            return this.ItemsPedido.Any()
                ? this.ItemsPedido.Sum(_ => _.Valor)
                : 0;
        }
    }

    public class ItemPedido
    {
        [Key]
        int CodigoItemPedido { get; set; }
        public int CodigoProduto { get; set; }
        public int NumeroPedido { get; set; }
        public int Quantidade { get; set; } 
        public decimal Valor { get; set; }
    }

    public class Teste
    {
        IList<Pedido> pedidos = from p in pedidos where Data.Year == 2017 && Cpf == "1";
        var total = pedidos.Sum(_ => _.ValorTotal());
    }
}
