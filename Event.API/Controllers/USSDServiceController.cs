using System;
using System.Net;
using System.Net.Http;
using System.Text;
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class USSDServiceController : ControllerBase
    {
        private readonly IFileLogger _fileLogger;

        public USSDServiceController(IFileLogger fileLogger)
        {
            _fileLogger = fileLogger;
        }

        [HttpPost]
        [Route("approverequest")]
        public ContentResult ApproveRequest([FromBody] UssdResponse ussdResponse)
        {
            string response;

            if (ussdResponse.text == null)
            {
                ussdResponse.text = "";
            }

            if (ussdResponse.text.Equals("", StringComparison.Ordinal))
            {
                response = "CON USSD Demo in Action\n";
                response += "1. Do something\n";
                response += "2. Do some other thing\n";
                response += "3. Get my Number\n";
            }
            else if (ussdResponse.text.Equals("1", StringComparison.Ordinal))
            {
                response = "END I am doing something \n";
            }
            else if (ussdResponse.text.Equals("2", StringComparison.Ordinal))
            {
                response = "END Some other thing has been done \n";
            }
            else if (ussdResponse.text.Equals("3", StringComparison.Ordinal))
            {
                response = $"END Here is your phone number : {ussdResponse.phoneNumber} \n";
            }
            else
            {
                response = "END Invalid option \n";
            }

            return new ContentResult
            {
                Content = response,
                ContentType = "text/plain",
                StatusCode = 200,
            };
        }


        [HttpPost]
        [Route("approverequesttwo")]
        public HttpResponseMessage ApproveRequestTwo([FromBody] UssdResponse ussdResponse)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            string response;

            if (ussdResponse.text == null)
            {
                ussdResponse.text = "";
            }

            if (ussdResponse.text.Equals("", StringComparison.Ordinal))
            {
                response = "CON USSD Demo in Action\n";
                response += "1. Do something\n";
                response += "2. Do some other thing\n";
                response += "3. Get my Number\n";
            }
            else if (ussdResponse.text.Equals("1", StringComparison.Ordinal))
            {
                response = "END I am doing something \n";
            }
            else if (ussdResponse.text.Equals("2", StringComparison.Ordinal))
            {
                response = "END Some other thing has been done \n";
            }
            else if (ussdResponse.text.Equals("3", StringComparison.Ordinal))
            {
                response = $"END Here is your phone number : {ussdResponse.phoneNumber} \n";
            }
            else
            {
                response = "END Invalid option \n";
            }

            responseMessage.Content = new StringContent(response, Encoding.UTF8, "text/plain");

            return responseMessage;
        }

    }
}