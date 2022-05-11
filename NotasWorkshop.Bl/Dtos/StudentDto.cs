using SicopataSchool.Core.BaseModel.BaseEntityDto;
using SicopataSchool.Model.Entities;
using System.Text.Json.Serialization;

namespace SicopataSchool.Bl.Dtos
{
    public class StudentDto : BaseEntityDto
    {
        [JsonIgnore]
        public override int? Id { get => base.Id; set => base.Id = value; }
        [JsonIgnore]
        public override bool Deleted { get => base.Deleted; set => base.Deleted = value; }
   
        public string? EnrollmentCode { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
