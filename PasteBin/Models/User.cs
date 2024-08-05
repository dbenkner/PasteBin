using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PasteBin.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; } = string.Empty;
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(255)]
        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        [MaxLength(255)]
        [JsonIgnore]
        public byte[] PasswordSalt { get; set;} = Array.Empty<byte>();  
    }
}
