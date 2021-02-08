namespace Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }

    }
}