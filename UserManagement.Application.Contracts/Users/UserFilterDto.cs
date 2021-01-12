using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Users
{
    public class UserFilterDto
    {
        public string TCKN { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
