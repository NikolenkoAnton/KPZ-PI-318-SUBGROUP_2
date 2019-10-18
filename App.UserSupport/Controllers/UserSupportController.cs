using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace App.UserSupport.Controllers
{
    [Route("api/UserSupport")]
    [ApiController]
    public class UserSupportController : ControllerBase
    {
        readonly IUserSupportManager _userSupportManager;
        public UserSupportController(
            IUserSupportManager userSupportManager)
        {
            _userSupportManager = userSupportManager;
        }

        [HttpGet("active")]
        public ActionResult<IEnumerable<string>> GetListActiveHandlings()
        {
            var serviceCallResult = _userSupportManager.GetListActiveHandlings().ToList();
            return serviceCallResult;
        }

        [HttpGet("{id}/last10Message")]
        public ActionResult<IEnumerable<string>> GetHandling10LastMessages(int id)
        {
            var serviceCallResult = _userSupportManager.GetHandling10LastMessages(id).ToList();
            return serviceCallResult;
        }

        [HttpPost]
        public void SetHandlingStatusCompletedById(int id)
        {
            _userSupportManager.SetHandlingStatusCompleted(id);

        }
    }
}
