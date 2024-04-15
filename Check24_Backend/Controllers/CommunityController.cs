using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Check24.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityRepository _repo;
        public CommunityController(ICommunityRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<List<Community>> ListAll()
        {
            return await _repo.ListAll();
        }
        [HttpPost]
        public async Task<Community> Add([FromBody] Community community)
        {
            return await _repo.Add(community);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        [HttpPut]
        public async Task Update([FromBody] Community community)
        {
            await _repo.Update(community);
        }
 
        [HttpPost("join-community")]
        public async Task JoinCommunity(Guid userId, Guid communityId)
        {
            await _repo.JoinCommunity(userId, communityId);
        }


        [HttpPut("{communityId}/points")]
        public async Task SetCommunityPoints(Community community)
        {
            await _repo.SetCommunityPoints(community);
        }

        [HttpGet("{communityId}/ranking")]
        public async Task<List<User>> GetCommunityUserRanking(Guid communityId)
        {
            return await _repo.GetCommunityUserRanking(communityId);
        }
    }
}
