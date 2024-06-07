using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class CreateCommentDTO
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
