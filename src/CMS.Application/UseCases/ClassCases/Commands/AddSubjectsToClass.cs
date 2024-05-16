﻿using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.ClassCases.Commands
{
    public class AddSubjectsToClass:IRequest<ResponseModel>
    {
        public Guid classId { get; set; }
        public List<string> Subjects { get; set; }
    }
}
