using App.Users.Domain;
using App.Users.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;


namespace App.Users.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
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
