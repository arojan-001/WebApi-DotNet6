using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public float Qnty { get; set; }
        public  List<Order> Order { get; set; }
    }
}
