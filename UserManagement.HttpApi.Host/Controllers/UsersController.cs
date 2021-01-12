using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Users;

namespace UserManagement.Controllers
{
    public class UsersController : AppController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto>> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAsync(id, cancellationToken);
            if (user != null)
            {
                return user;
            }

            return new NotFoundResult();
        }

        [HttpGet]
        public async Task<ApiResult<List<UserDto>>> GetListAsync([FromQuery]UserFilterDto input)
        {
            var result = await _userService.GetListAsync(input);
            return result;
        }

        [HttpPost]
        public async Task<ApiResult<UserDto>> CreateUser([FromQuery]CreateUpdateUserDto input, CancellationToken cancellationToken)
        {

            var result = await _userService.CreateAsync(input, cancellationToken);

            if (result == null)
                return new BadRequestResult();

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResult<UserDto>> UpdateUser(Guid id, [FromQuery]CreateUpdateUserDto input, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateAsync(id, input, cancellationToken);
            if (result == null)
                return new BadRequestResult();

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _userService.DeleteAsync(id, cancellationToken);
            if (deleted)
                return Ok(true);

            return new BadRequestResult();
        }
    }
}
