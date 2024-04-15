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

        public async Task CreateNewUser(string userName)
        {
            userName = userName.ToLower();

            if(await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == userName) != null)
            {
                throw new CustomException("User already exists");
            }

            User user = new()
            {
                Username = userName,
                RegistrationDate = DateTime.Now
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            await Login(userName);
        }

        public async Task<User?> Login(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == userName);
        }

        public async Task SetRankings()
        {
            var rankedUsers = await _context.Users
                .OrderByDescending(u => u.Points) 
                .ToListAsync();

            for (int i = 0; i < rankedUsers.Count; i++)
            {
                rankedUsers[i].Rank = i + 1;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetUserRank(User user)
        {
            var rankedUser = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);
            return rankedUser?.Rank ?? 0;
        }

        public async Task<List<User>> GetLeaderboard()
        {
            return await _context.Users.OrderByDescending(u => u.Rank).ToListAsync();
        }


        public async void GetFriendsByUserId(Guid id)
        {
            
        }
    }
}
