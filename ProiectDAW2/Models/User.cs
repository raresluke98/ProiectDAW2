using ProiectDAW2.Entities;
using System.Text.Json.Serialization;

namespace ProiectDAW2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}
