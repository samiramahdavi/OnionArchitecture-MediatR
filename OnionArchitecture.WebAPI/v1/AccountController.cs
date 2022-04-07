using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using OnionArchitecture.Service.Interface;
using System.Threading.Tasks;

namespace OnionArchitecture.WebAPI.v1
{
    /// <summary>
    /// account controller help us to register new user,authenticate a user,...
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Inject a account service
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            //throw new NotFoundException("a","b");
        }


        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="request">It contains an email and password to authenticate</param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.AuthenticateAsync(request, GenerateIPAddress());
                return Ok(result);
            }
            return BadRequest();
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="request">It contains the data you need to register </param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var origin = Request.Headers["origin"];
                return Ok(await _accountService.RegisterAsync(request, origin));
            }
            return BadRequest();
        }

        /// <summary>
        /// After registering, you need to confirm your email address
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        }

        /// <summary>
        /// If forgot your password, this method emails a link to a recovery password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                await _accountService.ForgotPassword(model, Request.Headers["origin"]);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Reaset your password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.ResetPassword(model));
            }
            return BadRequest();
        }


        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
