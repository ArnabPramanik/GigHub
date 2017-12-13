using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto Dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == Dto.FolloweeId))
            {
                return BadRequest("Followinng already exists. ");

            }

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = Dto.FolloweeId

            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}
