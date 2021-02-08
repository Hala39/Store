namespace Core.Entities
{
    public class ProductSize
    {
        public Size Size { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Stock { get; set; }
     
    }
}