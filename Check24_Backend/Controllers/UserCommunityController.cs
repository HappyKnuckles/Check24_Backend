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
    }
}
