using SicopataSchool.Core.BaseModel.BaseEntity;

namespace SicopataSchool.Model.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {
            this.Notes = new HashSet<Note>();
        } 
        public string? EnrollmentCode { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
