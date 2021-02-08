using System.Collections.Generic;

namespace Core.Dtos
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<WishDto> Wishes { get; set; }
    }
}