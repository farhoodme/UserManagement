using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Users;

namespace UserManagement
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUpdateUserDto input, CancellationToken cancellationToken);
        Task<UserDto> UpdateAsync(Guid id, CreateUpdateUserDto input, CancellationToken cancellationToken);
        Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<List<UserDto>> GetListAsync(UserFilterDto input);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
