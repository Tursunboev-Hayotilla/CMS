namespace CMS.Domain.Entities
{
    public class Examine
    {
        public Guid Id { get; set; }
        public virtual Subject SubjectId { get; set; }
        public virtual Class ClassId { get; set; }
        public required string Task { get; set; }
        public int Coin { get; set; }
        public string Result { get; set; }
    }
}
