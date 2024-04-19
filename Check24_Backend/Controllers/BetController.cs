using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository _repo;
        public BetController(IBetRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<Bet>> ListAll()
        {
            return await _repo.ListAll();
        }

        [HttpPost]
        public async Task<Bet> Add([FromBody] Bet bet)
        {
            return await _repo.Add(bet);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        [HttpPut]
        public async Task Update([FromBody] Bet bet)
        {
            await _repo.Update(bet);
        }

        [HttpPost("place-bet")]
        public async Task PlaceBet(int homeGoals, int awayGoals, int gameId, Guid userId)
        {
            await _repo.PlaceBet(homeGoals, awayGoals, gameId, userId);
        }

        [HttpGet("{id}/bets")]
        public async Task<List<Bet>> GetUserBets(Guid userId)
        {
            return await _repo.GetUserBets(userId);
        }
    }
}
