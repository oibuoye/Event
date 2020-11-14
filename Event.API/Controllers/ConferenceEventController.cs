using System;
using System.Threading.Tasks;
using Event.API.Controllers.Handlers.Contracts;
using Event.Core.Enums;
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

    }
}