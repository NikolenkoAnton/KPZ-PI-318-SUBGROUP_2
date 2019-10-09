using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace App.UserSupport.Controllers
{
    [Route("api/UserSupport")]
    [ApiController]
    public class UserSupportController : ControllerBase
    {
        readonly ISomeService _service;
        readonly IUserSupportManager _userSupportManager;
        public UserSupportController(
            ISomeService service,
            IUserSupportManager userSupportManager)
        {
            _service = service;
            _userSupportManager = userSupportManager;
        }

        // GET api/example/values
        [HttpGet("active")]
        public ActionResult<IEnumerable<string>> GetActiveValues()
        {
            _service.DoSmth();
            var serviceCallResult = _userSupportManager.GetActiveValues().ToList();
            return serviceCallResult;
        }
        [HttpGet("{id}/last_10_message")]
        public ActionResult<IEnumerable<string>> Get_Handling_10_last_messages(int id)
        {
            _service.DoSmth();
            var serviceCallResult = _userSupportManager.Get_Handling_10_last_messages(id).ToList();
            return serviceCallResult;
        }
        [HttpPost]
        public ActionResult<IEnumerable<string>> Set_Handling_Status_Completed(int id)
        {
            _service.DoSmth();
            _userSupportManager.Set_Handling_Status_Completed(id);
            var serviceCallResult = _userSupportManager.GetActiveValues().ToList();
            return serviceCallResult;
        }
    }
}
