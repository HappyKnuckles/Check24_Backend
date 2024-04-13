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
    }
}
