using System;
using System.Collections.Generic;
using System.Text;

namespace SicopataSchool.Core.BaseModel.BaseEntity
{
    public class BaseEntity : Base.Base, IBaseEntity
    {
        public virtual DateTimeOffset? CreatedDate { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual string? UpdatedBy { get; set; }
    }
}
