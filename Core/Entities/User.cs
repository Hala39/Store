using System;
namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public Cart Cart { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}