using System.Collections.Generic;

namespace Core.Entities
{
    public class ProductColor
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; }

    }
}