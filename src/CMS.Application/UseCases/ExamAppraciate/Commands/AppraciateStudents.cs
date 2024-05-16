using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ExamAppraciate.Commands
{
    public class AppreciateStudentsExamCommand:IRequest<ResponseModel>
    {
        public Guid ExamId { get; set; }
        public List<Student> StudentIds { get; set; }
        public int Coins { get; set; }
    }
}
