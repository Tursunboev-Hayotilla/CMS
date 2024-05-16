using CMS.Domain.Entities.Auth;
using System.Text.Json.Serialization;

namespace CMS.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required byte Grade { get; set; }
        public string TeacherId { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual Teacher Teacher{ get; set; }
    }
}
