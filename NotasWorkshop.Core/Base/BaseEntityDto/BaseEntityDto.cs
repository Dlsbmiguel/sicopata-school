using System;
using System.Collections.Generic;
using System.Text;

namespace SicopataSchool.Core.BaseModel.BaseEntityDto
{
    public class BaseEntityDto : BaseDto.BaseDto, IBaseEntityDto
    {
        public string CreatedBy { get; set; }
        public virtual string UpdatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
