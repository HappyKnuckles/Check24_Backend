using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<User> Add([FromBody] User user)
        {
            return await _repo.Add(user);
        }
        [HttpGet]
        public async Task<List<User>> ListAll()
        {
            return await _repo.ListAll();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        [HttpPut]
        public async Task Update([FromBody] User user)
        {
            await _repo.Update(user);
        }

        [HttpGet("login")]
        public async Task<User?> Login(string userName)
        {
            return await _repo.Login(userName);
        }

        [HttpGet("rank")]
        public async Task<User> GetUserRank(string userName)
        {
            return await _repo.GetUserRank(userName);
        }
        [HttpGet("get-leaderboard")]
        public async Task<List<User>> GetLeaderboard()
        {
            return await _repo.GetLeaderboard();
        }

    }
}
