﻿using CMS.Domain.Entities.Models;

namespace CMS.Domain.Entities
{
    public class Examine
    {
        public Guid Id { get; set; }
        public required string Task { get; set; }
        public int Coin { get; set; }

        /*// Shuni nma qilishini chunmadim to'grisi
        public string Result { get; set; }*/
        public Guid SubjectId { get; set; }
        public virtual CustomeDate Date { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Class Class { get; set; }
    }
}