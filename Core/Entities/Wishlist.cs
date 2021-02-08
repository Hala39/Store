using System.Collections.Generic;

namespace Core.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Wish> Wishes { get; set; }
    }
}