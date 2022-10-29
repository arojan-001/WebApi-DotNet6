namespace WebApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public float Qnty { get; set; }
    }
}
