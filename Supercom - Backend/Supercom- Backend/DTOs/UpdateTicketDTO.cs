using Supercom__Backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class UpdateTicketDTO
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus? Status { get; set; }
    }
}
