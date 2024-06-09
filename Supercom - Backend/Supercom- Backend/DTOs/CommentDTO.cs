using Supercom__Backend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }
    }
}
