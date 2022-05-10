using SicopataSchool.Bl.Dtos;
using SicopataSchool.Bl.Validators.Generic;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.Bl.Validators
{
    internal class StudentValidator: BaseValidator<StudentDto>
    {
        public StudentValidator()
        {
            
        }
    }
}
