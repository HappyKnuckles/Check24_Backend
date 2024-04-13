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
    }
}
