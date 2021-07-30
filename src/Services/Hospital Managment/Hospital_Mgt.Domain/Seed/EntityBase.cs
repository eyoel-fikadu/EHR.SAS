﻿using System;

namespace HospitalMgt.Domain.Seed
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
