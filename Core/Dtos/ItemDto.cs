using Core.Entities;

namespace Core.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}