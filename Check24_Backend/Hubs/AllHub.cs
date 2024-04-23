using Check24.Core;
using Check24.Core.dtos;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Check24.Api.Hubs
{
    public class AllHub : Hub
    {
        private readonly ICommunityRepository _communityRepo;
        private readonly IUserRepository _userRepo;

        public AllHub(ICommunityRepository communityRepo, IUserRepository userRepo)
        {
            _communityRepo = communityRepo;
            _userRepo = userRepo;
        }

        //public async Task UpdateGameAndUserData(Game game)
        //{
        //    await _userRepo.UpdatePointsForGameResult(game.GameId);
        //    await _communityRepo.SetAllCommunityPoints();
        //    var communityMembers = await _communityRepo.GetCommunityUserRanking(null);
        //    await Clients.All.SendAsync("UpdateUserRanking", communityMembers);
        //    await Clients.All.SendAsync("UpdateGameScore", game);
        //}
    }
}
