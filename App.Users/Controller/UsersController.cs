using App.Models.Users;
using App.Users.Filters;
using App.Users.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace App.Users.Controller
{
    [Route("api/users")]
    [ApiController]
    [TypeFilter(typeof(UsersExceptionFilter), Arguments = new object[] { nameof(UsersController) })]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet("allAvailable")]
        public ActionResult<List<User>> GetAllActive()
        {
            logger.LogInformation("Call GetAllActive method");
            return userService.GetAllActive();
        }

        [HttpPost("changePassword")]
        public ActionResult ChangePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            logger.LogDebug($"Call ChangePassword method with login={userId}, oldPassword={oldPassword}, newPassword={newPassword}, confirmPassword={confirmPassword}");
            logger.LogInformation($"Call ChangePassword method with login={userId}");
            userService.ChangePassword(userId, oldPassword, newPassword, confirmPassword);
            return Ok();
        }

        [HttpPost("block")]
        public ActionResult BlockUser(int userId)
        {
            logger.LogInformation($"Call BlockUser method with login={userId}");
            userService.BlockUser(userId);
            return Ok();
        }

        [HttpPost("unblock")]
        public ActionResult UnblockUser(int userId)
        {
            logger.LogInformation($"Call UnblockUser method with login={userId}");
            userService.UnblockUser(userId);
            return Ok();
        }
    }
}
