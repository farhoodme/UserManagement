using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Entities;
using UserManagement.Repositories;
using UserManagement.Users;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly UserManager _userManager;
        private readonly IMapper _mapper;

        public UserService(IRepository<User, Guid> userRepository, UserManager userManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUpdateUserDto input, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = input.Name,
                Surname = input.Surname,
                BirthDate = input.BirthDate,
                Address = input.Address
            };

            var chkTCKN = await _userManager.IsUserTCKNCodeExist(user.TCKN);

            if (!chkTCKN)
            {
                user.LastModificationTime = DateTime.Now;
                user.CreationTime = DateTime.Now;
                await _userRepository.AddAsync(user, cancellationToken);
                return _mapper.Map<User, UserDto>(user);
            }

            return null;
        }

        public async Task<UserDto> UpdateAsync(Guid id, CreateUpdateUserDto input, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);

            if (user != null)
            {
                user.Name = input.Name;
                user.Surname = input.Surname;
                user.BirthDate = input.BirthDate;
                user.Address = input.Address;
                user.LastModificationTime = DateTime.Now;
                await _userRepository.UpdateAsync(user, cancellationToken);
                return _mapper.Map<User, UserDto>(user);
            }
            else
                return null;
            
        }

        public async Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.TableNoTracking.SingleOrDefaultAsync(i => i.Id == id, cancellationToken);

            var model = _mapper.Map<User, UserDto>(user);

            return model;
        }

        public async Task<List<UserDto>> GetListAsync(UserFilterDto input)
        {
            var query = _userRepository.TableNoTracking.AsQueryable();

            if (!string.IsNullOrEmpty(input.TCKN))
            {
                query = query.Where(i => i.TCKN == input.TCKN);
            }

            var totalCount = query.Count();


            var entities = await query
                .OrderBy(i => i.TCKN)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount > 0 ? input.MaxResultCount : 10)
                .ToListAsync();

            return _mapper.Map<List<User>, List<UserDto>>(entities);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user, cancellationToken);
                return true;
            }

            return false;
        }
    }
}
