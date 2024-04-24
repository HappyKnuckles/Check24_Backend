using Check24.Api.Hubs;
using Check24.Core;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repo;
        private readonly IHubContext<AllHub> _allHubContext;
        private readonly IBetRepository _betRepo;
        private readonly ICommunityRepository _communityRepo;

        public GameController(IGameRepository repo, IHubContext<AllHub> allHubContext, IBetRepository betRepo, ICommunityRepository communityRepo)
        {
            _repo = repo;
            _allHubContext = allHubContext;
            _betRepo = betRepo;
            _communityRepo = communityRepo;
        }

        [HttpGet]
        public async Task<List<Game>> ListAll()
        {
            return await _repo.ListAll();
        }

        [HttpPost]
        public async Task<Game> Add([FromBody] Game game)
        {
            return await _repo.Add(game);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        [HttpPut]
        public async Task Update([FromBody] Game game)
        {
            await _repo.Update(game);
        }
        [HttpGet("games-without-bets")]
        public async Task<List<Game>> GetGamesWithoutBet(Guid userId)
        {
            return await _repo.GetGamesWithoutBet(userId);
        }

        [HttpPost("goal")]
        public async Task SetGoal(bool teamAway, int gameId)
        {
            await _repo.SetGoal(teamAway, gameId);
            await _betRepo.UpdatePointsForGameResult(gameId);
            await _communityRepo.SetAllCommunityPoints();
            await _allHubContext.Clients.All.SendAsync("getCommunityUserRanking");
            await _allHubContext.Clients.All.SendAsync("getGames");
        }
    }
}
