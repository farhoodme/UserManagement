using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Users
{
    public class UserDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
