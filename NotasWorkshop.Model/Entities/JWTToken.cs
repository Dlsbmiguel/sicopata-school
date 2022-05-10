using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.Model.Entities
{
    public class JWTToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
