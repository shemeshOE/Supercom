using Supercom__Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class CreateTicketDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
