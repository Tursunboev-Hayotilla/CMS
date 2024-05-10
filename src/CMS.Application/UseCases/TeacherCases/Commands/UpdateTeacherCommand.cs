using CMS.Domain.Entities.Enums;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CMS.Domain.Entities.Models;

namespace CMS.Application.UseCases.TeacherCases.Commands
{
    public class UpdateTeacherCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; } = new Guid();

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Gender Gender { get; set; }
        public string? PhotoPath { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public virtual Subject SubjectId { get; set; }
        public virtual Location LocationId { get; set; }
    }
}
