namespace Supercom__Backend.Model
{
    public abstract class DatedEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
