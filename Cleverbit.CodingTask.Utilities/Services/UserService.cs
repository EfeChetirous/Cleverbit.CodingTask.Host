using Cleverbit.CodingTask.Data.DBProvider;
using Cleverbit.CodingTask.Data.Entities;
using Cleverbit.CodingTask.Utilities.Extensions;
using Cleverbit.CodingTask.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Utilities.Services
{
    public class UserService : IUserService
    {
        private readonly CleverbitDBContext _context;

        public UserService(CleverbitDBContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _context.User.FirstOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Task.Run(() => _context.User.ToList());
        }
    }
}
