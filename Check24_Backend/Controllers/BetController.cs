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
        public class BetInputModel
        {
            public Game Game { get; set; }
            public Bet Bet { get; set; }
            public User User { get; set; }
        }

        [HttpPost("place-bet")]
        public async Task PlaceBet([FromBody] BetInputModel betInput)
        {
            await _repo.PlaceBet(betInput.Game, betInput.Bet, betInput.User);
        }
    }
}
