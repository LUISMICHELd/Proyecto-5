
using System.Collections.Generic;
using SistemaDelivery.Models;

namespace SistemaDelivery.Services
{
    public class DeliveryService
    {
        private List<Delivery> deliveries = new List<Delivery>();
        private int nextId = 1;

        public List<Delivery> FindAll()
        {
            return deliveries;
        }

        public void Add(string cliente, string direccion, string pedido)
        {
            Delivery delivery = new Delivery(
                nextId,
                cliente,
                direccion,
                pedido
            );

            deliveries.Add(delivery);
            nextId++;
        }

        public bool Delete(int id)
        {
            Delivery delivery = deliveries.Find(d => d.Id == id);

            if (delivery == null)
            {
                return false;
            }

            deliveries.Remove(delivery);
            return true;
        }
    }
}
