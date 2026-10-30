
namespace SistemaDelivery.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Pedido { get; set; }

        public Delivery(int id, string cliente, string direccion, string pedido)
        {
            Id = id;
            Cliente = cliente;
            Direccion = direccion;
            Pedido = pedido;
        }
    }
}
