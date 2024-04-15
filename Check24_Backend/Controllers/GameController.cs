using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repo;
        public GameController(IGameRepository repo)
        {
            _repo = repo;
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
    }
}
