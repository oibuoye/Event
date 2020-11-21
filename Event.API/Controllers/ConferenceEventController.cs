using System;
using System.Threading.Tasks;
using Event.API.Controllers.Handlers.Contracts;
using Event.Core.Enums;
using Event.Core.Exceptions;
using Event.Core.HelperModels;
using Event.Core.Logger.Contracts;
using Event.Core.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConferenceEventController : ControllerBase
    {
        private readonly IConferenceEventHandler _eventHandler;
        private readonly IFileLogger _fileLogger;

        public ConferenceEventController(IConferenceEventHandler eventHandler, IFileLogger fileLogger)
        {
            _eventHandler = eventHandler;
            _fileLogger = fileLogger;
        }

        [AllowAnonymous]
        [HttpPost]
        [EnableCors("AllowOrigin")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] EventCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _eventHandler.AddEvent(model);
                    return Ok(new APIResponse { ResponseObject = response });
                }
                else
                {
                    return BadRequest(new APIResponse { Error = true, ErrorMessage="Bad request", ErrorCode="001" });
                }
            }
            catch (RecordAlreadyExistException ex)
            {
                return BadRequest(new APIResponse { Error = true, ErrorMessage = "Bad request", ErrorCode = "001" });
            }
            catch (Exception)
            {
                return BadRequest(new APIResponse { Error = true, ErrorMessage = "Exception", ErrorCode = "999" });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [EnableCors("AllowOrigin")]
        [Route("list")]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                var events = await _eventHandler.GetEvents();
                return Ok(events);
            }
            catch (Exception)
            {
                return BadRequest(new APIResponse { Error = true, ErrorMessage = "Exception", ErrorCode = "999" });
            }
        }
    }
}