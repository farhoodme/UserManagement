using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities;
using UserManagement.Repositories;

namespace UserManagement.Users
{
    public class UserManager
    {
        private readonly IRepository<User, Guid> _userRepository;

        public UserManager(IRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsUserTCKNCodeExist(string code)
        {
            var existingUser = await _userRepository.TableNoTracking.SingleOrDefaultAsync(i => i.TCKN == code);
            if (existingUser != null)
            {
                return true;
            }

            return false;
        }
    }
}
