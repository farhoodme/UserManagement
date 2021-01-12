using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Operation Successful")]
        Success = 0,

        [Display(Name = "Server Error")]
        ServerError = 1,

        [Display(Name = "Bad Request")]
        BadRequest = 2,

        [Display(Name = "Not Found")]
        NotFound = 3,

        [Display(Name = "Empty List")]
        ListEmpty = 4,

        [Display(Name = "Logic Error")]
        LogicError = 5,

        [Display(Name = "UnAuthorized")]
        UnAuthorized = 6
    }
}
