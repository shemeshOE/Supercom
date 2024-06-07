using Supercom__Backend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supercom__Backend.DTOs
{
    public class UpdateCommentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
