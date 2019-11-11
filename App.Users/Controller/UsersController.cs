using App.Users.Domain;
using App.Users.Filters;
using App.Users.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Users.Controller
{
    [Route("api/users")]
    [ApiController]
    [TypeFilter(typeof(UsersExceptionFilter), Arguments = new object[] { nameof(UsersController) })]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("allAvailable")]
        public ActionResult<List<User>> GetAllActive() => Ok(userService.GetAllActive());

        [HttpPost("changePassword")]
        public ActionResult ChangePassword(string login, string oldPassword, string newPassword, string confirmPassword)
        {
            userService.ChangePassword(login, oldPassword, newPassword, confirmPassword);
            return Ok();
        }

        [HttpPost("block")]
        public ActionResult BlockUser(string login)
        {
            userService.BlockUser(login);
            return Ok();
        }

        [HttpPost("unblock")]
        public ActionResult UnblockUser(string login)
        {
            userService.UnblockUser(login);
            return Ok();
        }
    }
}
