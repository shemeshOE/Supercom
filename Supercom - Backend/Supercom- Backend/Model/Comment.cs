using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.Model
{
    public class Comment : DatedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }

        [Required]
        public string Text { get; set; }

        public Ticket Ticket { get; set; }
    }
}
