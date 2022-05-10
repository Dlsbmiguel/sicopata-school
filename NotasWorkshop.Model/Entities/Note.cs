using SicopataSchool.Core.BaseModel.BaseEntity;

namespace SicopataSchool.Model.Entities
{
    public class Note : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int? StudentId { get; set; }
        public bool IsPrivate { get; set; }
        public virtual Student? Student { get; set; }
    }
}
