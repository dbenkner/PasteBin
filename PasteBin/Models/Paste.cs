using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PasteBin.Models
{
    [Index(nameof(PasteURL),IsUnique =true)]
    public class Paste
    {
        public int Id { get; set; }
        
        public string PasteText { get; set; } = string.Empty;
        [StringLength(8)]
        public string PasteURL { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public virtual User? User { get; set; }
        public int? UserID { get; set; }
    }
}
