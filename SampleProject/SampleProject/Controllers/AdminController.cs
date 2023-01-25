using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Model;
using System.Data;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpPost("GetAdminDeatils")]
        public AdminDeatails GetDeatils(Details user)
        {
            AdminDeatails user1 = new AdminDeatails();
            user1.name = user.name;
            user1.email = user.email;
            user1.description = "Hello I am admin of sample project you can only acess this controller only if you have admin access";
            user1.Role = "Admin";

            return user1;

        }
    }
}
