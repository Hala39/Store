using System.Collections.Generic;
using System.Text.Json.Serialization;
using Core.Entities;

namespace Core.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int EntryYear { get; set;}
        public int EntryMonth { get; set; }
        public int EntryDay { get; set; }
        public bool Offer { get; set; }
        public decimal NewPrice { get; set; }

    }
}