using System.Collections.Generic;

namespace Core.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductColor> AvailableColors { get; set; }
    }
}