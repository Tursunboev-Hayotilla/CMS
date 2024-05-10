using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Homework
    {
        public Guid Id { get; set; } = new Guid();
        public object lessonId { get; set; }
        public string result { get; set; }
        public int coin { get; set; }
        public required DateTimeOffset startDate { get; set; }
        public required DateTimeOffset endDate { get; set;}

    }
}
