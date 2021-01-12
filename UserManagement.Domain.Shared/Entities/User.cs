using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserManagement.Filters;
using UserManagement.Users;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class User : Entity<Guid>, IAuditedObject
    {
        public User()
        {
            TCKN = UserTCKN.GenerateCode();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(UserConsts.MaxTCKNLength)]
        public string TCKN { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModificationTime { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (UserTCKN.IsValidCode(TCKN))
            {
                yield return new ValidationResult(
                    "TCKN is not a valid code!",
                    new[] { "TCKN" }
                );
            }
        }
    }
}
