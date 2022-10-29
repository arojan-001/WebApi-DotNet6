using System.Text.Json.Serialization;
namespace WebApi.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Valuedate { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
