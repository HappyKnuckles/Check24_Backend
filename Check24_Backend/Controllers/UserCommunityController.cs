using Check24.Core.dtos;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Check24.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCommunityController : ControllerBase
    {
        private readonly IUserCommunityRepository _repo;
        public UserCommunityController(IUserCommunityRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("show-user-communities")]
        public async Task<List<CommunityMembersDto>> GetUserCommunitiesWithOtherUsers(Guid userId)
        {
            return await _repo.GetUserCommunitiesWithOtherUsers(userId);
        }

        [HttpPost]
        public async Task<UserCommunity> Add([FromBody] UserCommunity userCommunity)
        {
            return await _repo.Add(userCommunity);
        }
        [HttpGet]
        public async Task<List<UserCommunity>> ListAll()
        {
            return await _repo.ListAll();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        [HttpPut]
        public async Task Update([FromBody] UserCommunity userCommunity)
        {
            await _repo.Update(userCommunity);
        }

    }
}
