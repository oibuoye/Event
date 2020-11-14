using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Event.Core.Configuration;
using Event.Core.Entities;
using Event.Core.Enums;
using Event.Core.Exceptions;
using Event.Core.HelperModels;
using Event.Core.Logger.Contracts;
using Event.Core.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Event.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IFileLogger _fileLogger;
        private readonly IJwtSettings _jwtSettings;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IFileLogger fileLogger, IJwtSettings jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileLogger = fileLogger;
            _jwtSettings = jwtSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        [EnableCors("AllowOrigin")]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        double defaultTokenExpirePeriod = 30;
                        if (_jwtSettings.ExpirePeriod != 0)
                        {
                            defaultTokenExpirePeriod = _jwtSettings.ExpirePeriod;
                        }

                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            claims: claims,
                            signingCredentials: credentials,
                            expires: DateTime.Now.AddMinutes(defaultTokenExpirePeriod)
                            );

                        _fileLogger.Info($"User with email {model.Email} is yet to be verified.");
                        return BadRequest(new APIResponse { Error = true, ErrorMessage = ResponseCodeDescription.Account_Unverified(), ErrorCode = ErrorCode.Account_Unverified.ToDescription(), ResponseObject = new { Message = "Token has been sent to user email", Code = ResponseCode.Success.ToDescription(), AuthorizationToken = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo } });

                        //Check the role
                        var user = await _userManager.FindByNameAsync(model.Email);
                        var role = await _userManager.GetRolesAsync(user);
                        return Ok(new APIResponse { Error = false, ResponseObject = new { Message = "Successful", Code = ResponseCode.Success.ToDescription(), RoleName = role.FirstOrDefault() } });
                    }
                    else if (result.IsLockedOut)
                    {
                        _fileLogger.Info($"User account locked out for user {model.Email}.");
                        return BadRequest(new APIResponse { Error = true, ErrorMessage = ResponseCodeDescription.Account_Locked(), ErrorCode = ErrorCode.Account_Locked.ToDescription() });
                    }
                    else
                    {
                        _fileLogger.Info($"Invalid login details for user {model.Email}.");
                        return BadRequest(new APIResponse { Error = true, ErrorMessage = ResponseCodeDescription.Invalid_Login(), ErrorCode = ErrorCode.Invalid_Login.ToDescription() });
                    }
                }
                _fileLogger.Error($"Bad request");
                return BadRequest(new APIResponse { ErrorMessage = "Bad request, all fields are required", Error = true, ErrorCode = ErrorCode.Bad_Model.ToDescription() });
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex.Message, ex);
                return BadRequest(new APIResponse
                {
                    Error = true,
                    ErrorMessage = ResponseCodeDescription.General_Exception(),
                    ErrorCode = ErrorCode.General_Exception.ToDescription()
                });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [EnableCors("AllowOrigin")]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] SelfRegistrationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //await _selfRegistrationHandler.Create(model);

                    double defaultTokenExpirePeriod = 30;
                    if (_jwtSettings.ExpirePeriod != 0)
                    {
                        defaultTokenExpirePeriod = _jwtSettings.ExpirePeriod;
                    }

                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        signingCredentials: credentials,
                        expires: DateTime.Now.AddMinutes(defaultTokenExpirePeriod)
                        );

                    return Ok(new APIResponse { Error = false, ResponseObject = new { Message = "Token has been sent to user email", Code = ResponseCode.Success.ToDescription(), AuthorizationToken = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo } });
                }

                _fileLogger.Error($"Bad request");
                return BadRequest(new APIResponse { ErrorMessage = "Bad request, all fields are required", Error = true, ErrorCode = ErrorCode.Bad_Model.ToDescription() });
            }
            catch (RecordAlreadyExistException ex)
            {
                _fileLogger.Error(ex.Message, ex);
                return BadRequest(new APIResponse { Error = true, ErrorMessage = ResponseCodeDescription.Record_Already_Exist($"{ex.Message}"), ErrorCode = ErrorCode.Record_Exist.ToDescription() });
            }
            catch (IdentityPasswordStrengthException ex)
            {
                _fileLogger.Error(ex.Message, ex);
                return BadRequest(new APIResponse { Error = true, ErrorMessage = ResponseCodeDescription.Password_Error($"{ex.Message}"), ErrorCode = ErrorCode.Password_Error.ToDescription() });
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex.Message, ex);
                return BadRequest(new APIResponse
                {
                    Error = true,
                    ErrorMessage = ResponseCodeDescription.General_Exception(),
                    ErrorCode = ErrorCode.General_Exception.ToDescription()
                });
            }
        }

    }
}