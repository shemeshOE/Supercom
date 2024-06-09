using Supercom__Backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public TicketStatus Status { get; set; }
    }
}
