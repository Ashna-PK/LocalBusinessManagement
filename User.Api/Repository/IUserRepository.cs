using System.Collections.Generic;
using User.Api.Data;
using User.Api.Models;

namespace User.Api.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserClass>> getUser();
        public Task<UserClass> getUserById(int id);
        public Task<UserClass> createUser(UserDto user);
        public Task<UserClass> editProfile(int id,UserClass user);
        public Task<bool> deleteUser(int id);

    }
}
