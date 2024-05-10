using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Examine
    {
        public Guid Id { get; set; }
        public object SubjectId { get; set; }
        public object ClassId { get; set; }
        public string Task { get; set; }
        public int Coin { get; set; }
        public string Result { get; set; }
    }
}
