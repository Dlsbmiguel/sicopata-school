using SicopataSchool.Core.BaseModel.BaseEntityDto;
using System.Text.Json.Serialization;

namespace SicopataSchool.Bl.Dtos
{
    public class NoteDto : BaseEntityDto
    {
        //[JsonIgnore]
        public override int? Id { get => base.Id; set => base.Id = value; }
        [JsonIgnore]
        public override bool Deleted { get => base.Deleted; set => base.Deleted = value; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPrivate { get; set; }
        public int StudentId { get; set; }

    }
}
