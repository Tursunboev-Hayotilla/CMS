using CMS.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities.Models
{
    public class ExamAppraciateStudent
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string StudentId { get; set; }
        public int Coins { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
