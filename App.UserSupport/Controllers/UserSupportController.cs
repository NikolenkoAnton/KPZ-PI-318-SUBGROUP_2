using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace App.UserSupport.Controllers
{
    [Route("api/UserSupport")]
    [ApiController]
    public class UserSupportController : ControllerBase
    {
        readonly IAnotherService _service;
        readonly IUserSupportManager _userSupportManager;
        public UserSupportController(
            IAnotherService service,
            IUserSupportManager userSupportManager)
        {
            _service = service;
            _userSupportManager = userSupportManager;
        }

        [HttpGet("active")]
        public ActionResult<IEnumerable<string>> GetActiveValues()
        {
            _service.DoAnything();
            var serviceCallResult = _userSupportManager.GetActiveValues().ToList();
            return serviceCallResult;
        }

        [HttpGet("{id}/last10Message")]
        public ActionResult<IEnumerable<string>> GetHandling10LastMessages(int id)
        {
            _service.DoAnything();
            var serviceCallResult = _userSupportManager.GetHandling10LastMessages(id).ToList();
            return serviceCallResult;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> SetHandlingStatusCompleted(int id)
        {
            _service.DoAnything();
            _userSupportManager.SetHandlingStatusCompleted(id);
            var serviceCallResult = _userSupportManager.GetActiveValues().ToList();
            return serviceCallResult;
        }
    }
}
