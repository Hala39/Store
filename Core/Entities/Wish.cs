namespace Core.Entities
{
    public class Wish
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public decimal OPrice { get; set; }
        public Wishlist Wishlist { get; set; }
        public int WishlistId { get; set; }
    }
}