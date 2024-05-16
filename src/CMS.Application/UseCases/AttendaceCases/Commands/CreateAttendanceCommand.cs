﻿using CMS.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.AttendaceCases.Commands
{
    public class CreateAttendanceCommand:IRequest<ResponseModel>
    {
        public string Theme {  get; set; }
        public Guid ClassId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsPresent { get; set; }
    }
}
