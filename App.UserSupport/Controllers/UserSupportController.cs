using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace App.UserSupport.Controllers
{
    /// <summary>
    /// This is example controller
    /// IMPORTANT the route to your won module should be 'api/{yourModuleName}' in order to avoid conflicts with other modules
    /// </summary>
    [Route("api/UserSupport/values")]
    [ApiController]
    public class UserSupportController : ControllerBase
    {
        // depedencies will be automatically resolved with used DI system
        readonly ISomeService _service;
        readonly IAnotherService _anotherService;
        readonly ILogger<UserSupportController> _logger;
        readonly IUserSupportManager _userSupportManager;
        public UserSupportController(
            ISomeService service,
            IAnotherService anotherService,
            ILogger<UserSupportController> logger,
            IUserSupportManager userSupportManager)
        {
            _service = service;
            _anotherService = anotherService;
            _logger = logger;
            _userSupportManager = userSupportManager;
        }

        // GET api/example/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _service.DoSmth();
            _anotherService.DoAnything();
            _logger.LogInformation("NOTHING");
            var serviceCallResult = _userSupportManager.GetValues().ToList();
            return serviceCallResult;
        }
    }
}
