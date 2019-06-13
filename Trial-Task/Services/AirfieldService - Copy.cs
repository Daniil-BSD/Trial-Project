using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository  _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
    }
}
