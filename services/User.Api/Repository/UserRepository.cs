using User.Api.Models;

namespace User.Api.Repository
{
    public class UserRepository
    {
        public Task<string> createUser()
        {
            throw new NotImplementedException();
        }

        public Task<string> deleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> editProfile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserClass>> getUser()
        {
            throw new NotImplementedException();
        }

        public Task<UserClass> getUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
