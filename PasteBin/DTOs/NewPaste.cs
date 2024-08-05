namespace PasteBin.DTOs
{
    public class NewPaste
    {
        public string PasteText { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
