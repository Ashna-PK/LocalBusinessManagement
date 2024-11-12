using System.Collections.Generic;
using User.Api.Models;

namespace User.Api.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserClass>> getUser();
        public Task<UserClass> getUserById(int id);
        public Task<string> createUser(UserClass user);
        public Task<string> editProfile(int id);
        public Task<string> deleteUser(int id);

    }
}
