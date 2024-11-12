using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Api.Data;
using User.Api.Models;

namespace User.Api.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserClass>> getUser()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<UserClass> getUserById(int id)
        {
            var userClass = await _context.Users.FindAsync(id);

            if (userClass == null)
            {
                return null;
            }

            return userClass;
        }
        public async Task<UserClass> createUser(UserDto userClass)
        {
            UserClass UserClass = new UserClass()
            {
                Address = userClass.Address,
                Email = userClass.Email,
                Name = userClass.Name,
                PhoneNo = userClass.PhoneNo,
            };
           await _context.Users.AddAsync(UserClass);
            await _context.SaveChangesAsync();
            
             return UserClass ;
            
        }

        public async Task<bool> deleteUser(int id)
        {
            var userClass = await _context.Users.FindAsync(id);
            if (userClass == null)
            {
                return false;
            }

            _context.Users.Remove(userClass);
            await _context.SaveChangesAsync();

            return true;
        }

        public async  Task<UserClass> editProfile(int id, UserClass userClass)
        {
            if (id != userClass.Id)
            {
                return null;
            }

            _context.Entry(userClass).State = EntityState.Modified;
            var result=_context.Users.Any(e => e.Id == id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            var user = await _context.Users.FindAsync(id);
            return user;
        }

       
    }
}
