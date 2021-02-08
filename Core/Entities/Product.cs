using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int EntryYear { get; set;}
        public int EntryMonth { get; set; }
        public int EntryDay { get; set; }
        public bool Offer { get; set; }
        public decimal NewPrice { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProductColor> AvailableColors { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }
    }
}