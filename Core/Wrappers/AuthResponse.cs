using System;

namespace Core.Wrappers
{
    public class AuthResponse<T> : ServiceResponse<T>
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}