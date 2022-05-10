using SicopataSchool.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SicopataSchool.Core.BaseModel.BaseEntity
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
