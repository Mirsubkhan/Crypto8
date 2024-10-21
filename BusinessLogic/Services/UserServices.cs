using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserServices(IUserRepository userRepository): IUserService
    {


        public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            User u = new User { Id = user.Id, UserName = user.UserName, Email = user.Email};

            await userRepository.CreateAsync(u, cancellationToken);
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
    }
}
