 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR_WebSocket_MSSQL.Models
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "User is required")]
        [StringLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; }
    }
}
