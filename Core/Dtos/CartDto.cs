using System.Collections.Generic;

namespace Core.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ItemDto> Items { get; set; }
    }
}