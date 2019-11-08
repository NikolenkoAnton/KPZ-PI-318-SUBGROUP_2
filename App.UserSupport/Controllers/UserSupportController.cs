using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.UserSupport.Filters;
using Microsoft.Extensions.Logging;

namespace App.UserSupport.Controllers
{
    [Route("api/UserSupport")]
    [ApiController]
    [TypeFilter(typeof(UserSupportExceptionFilter), Arguments = new object[] { nameof(UserSupportController) })]
    public class UserSupportController : ControllerBase
    {
        readonly IUserSupportManager _userSupportManager;
        readonly ILogger<UserSupportController> _logger;

        public UserSupportController(
            IUserSupportManager userSupportManager,
            ILogger<UserSupportController> logger)
        {
            _userSupportManager = userSupportManager;
            _logger = logger;
        }

        [HttpGet("active")]
        public ActionResult<IEnumerable<string>> GetListActiveHandlings()
        {
            _logger.LogInformation("call GetListActiveHandlings method");
            var serviceCallResult = _userSupportManager.GetListActiveHandlings().ToList();
            return serviceCallResult;
        }

        [HttpGet("{id}/last10Message")]
        public ActionResult<IEnumerable<string>> GetHandling10LastMessages(int id)
        {
            _logger.LogInformation("call GetHandling10LastMessages method");
            var serviceCallResult = _userSupportManager.GetHandling10LastMessages(id).ToList();
            return serviceCallResult;
        }

        [HttpPost]
        public void SetHandlingStatusCompletedById(int id)
        {
            _logger.LogInformation("call SetHandlingStatusCompleted method");
            _userSupportManager.SetHandlingStatusCompleted(id);
        }
    }
}
