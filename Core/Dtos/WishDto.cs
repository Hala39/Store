namespace Core.Dtos
{
    public class WishDto
    {
        public int Id { get; set; }
        public decimal OPrice { get; set; }
        public string Category { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int WishlistId { get; set; }
    }
}