using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Model;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="User")]
    [ApiController]
    public class UserContoller : Controller
    {

        [HttpPost("GetUserDeatils")]
        public UserDeatils GetDeatils(Details user)
        {
            UserDeatils user1 = new UserDeatils();
            user1.name = user.name;
            user1.email = user.email;
            user1.AcessTime = DateTime.Now;
            user1.Role = "Normal User";

            return user1;

        }
    }
}
