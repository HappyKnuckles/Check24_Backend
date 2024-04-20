using Check24.Core.dtos;
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


        [HttpPost("set-points")]
        public async Task SetCommunityPoints(Guid communityId)
        {
            await _repo.SetCommunityPoints(communityId);
        }

        [HttpGet("ranking")]
        public async Task<CommunityMembersDto> GetCommunityUserRanking(Guid? communityId)
        {
            return await _repo.GetCommunityUserRanking(communityId);
        }

        [HttpGet("communites-without-user")]
        public async Task<List<Community>> GetAllCommunitiesWithoutUser(Guid userId)
        {
            return await _repo.GetAllCommunitiesWithoutUser(userId);
        }

        [HttpPost("create-and-join-community")]
        public async Task CreateAndJoinCommunity(Guid userId, string communityName)
        {
            await _repo.CreateAndJoinCommunity(userId, communityName);
        }
    }
}
