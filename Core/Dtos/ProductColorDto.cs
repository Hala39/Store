using Core.Entities;

namespace Core.Dtos
{
    public class ProductColorDto
    {
        public int ProductId { get; set; }
        public string ColorName { get; set; }
        public int ColorId { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; }
    }
}