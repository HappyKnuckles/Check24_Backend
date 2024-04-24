using Check24.Core;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(Check24Context context) : base(context) { }

        public async Task<User?> Login(string userName)
        {
            var loggedInUser = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower());
            if (loggedInUser != null)
            {
                return loggedInUser;
            }
            else
            {
                User newUser = new()
                {
                    UserId = Guid.NewGuid(),
                    Username = userName,
                    RegistrationDate = DateTime.Now,
                    Points = 0
                };
                return loggedInUser = await Add(newUser);
            }
        }

        public async Task<User> GetUserRank(string userName)
        {

            var rankedUser = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower());
            if (rankedUser != null)
            {
                return rankedUser;
            }
            else throw new CustomException("Spieler nicht gefunden");
        }

        public async Task<List<User>> GetLeaderboard()
        {
            return await _context.Users.OrderByDescending(u => u.Points).ThenBy(u => u.RegistrationDate).ToListAsync();
        }
    }
}
