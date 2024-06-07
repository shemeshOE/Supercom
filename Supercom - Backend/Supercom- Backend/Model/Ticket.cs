using Supercom__Backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.Model
{
    public class Ticket:DatedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TicketStatus Status { get; set; }
        
        public IEnumerable<Comment> Comments { get; set; }
    }
}
