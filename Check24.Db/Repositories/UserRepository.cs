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
            else throw new CustomException("Kein Nutzer gefunden");
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
            return await _context.Users.OrderByDescending(u => u.Points).ToListAsync();
        }

        public int CalculatePointsForBet(Bet bet, int homeTeamGoals, int awayTeamGoals)
        {
            int points = 0;

            if (bet.HomeTeamGoals == homeTeamGoals && bet.AwayTeamGoals == awayTeamGoals)
            {
                points = 8;
            }
            else if (bet.HomeTeamGoals - bet.AwayTeamGoals == Math.Abs(homeTeamGoals - awayTeamGoals) && homeTeamGoals != awayTeamGoals)
            {
                points = 6;
            }
            else if ((bet.HomeTeamGoals > bet.AwayTeamGoals && homeTeamGoals > awayTeamGoals) ||
                     (bet.HomeTeamGoals == bet.AwayTeamGoals && homeTeamGoals == awayTeamGoals) ||
                     (bet.HomeTeamGoals < bet.AwayTeamGoals && homeTeamGoals < awayTeamGoals))
            {
                points = 4;
            }
            else
            {
                points = 0;
            }

            return points;
        }
        public async Task UpdatePointsForGameResult(Game game)
        {
            int homeTeamGoals = (int)game.TeamHomeGoals;
            int awayTeamGoals = (int)game.TeamAwayGoals;

            foreach (var bet in game.Bets)
            {
                int points = CalculatePointsForBet(bet, homeTeamGoals, awayTeamGoals);

                bet.User!.Points += points;

                _context.Entry(bet.User).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

    }
}
