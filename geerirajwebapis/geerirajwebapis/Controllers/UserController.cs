using geerirajwebapis.Model;
using geerirajwebapis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace geerirajwebapis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryAsync repositoryAsync;
        public UserController(IUserRepositoryAsync repositoryAsync)
        {
            this.repositoryAsync = repositoryAsync; 
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> UserLogIn([FromQuery] string MobileNo)
        {
            BaseRespons baseRespons = new BaseRespons();
            try
            {
                var result = await repositoryAsync.UserLogIn(MobileNo);
                if (result > 0)
                {
                    baseRespons.ResponseData = result;
                    baseRespons.StatusMessage = $"Otp Send Successfully...!";
                    baseRespons.StatusCode = StatusCodes.Status200OK;
                    return Ok(baseRespons);
                }
                else
                {
                    baseRespons.StatusMessage = "Something is wrong...!";
                    baseRespons.StatusCode = StatusCodes.Status400BadRequest;
                    baseRespons.ResponseData = 0;
                    return Ok(baseRespons);
                }
            }
            catch (Exception ex)
            {
                baseRespons.StatusMessage = ex.Message;
                baseRespons.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseRespons);
            }
        }
        [HttpGet("Validate")]
        public async Task<IActionResult> ValidateMobileNoAndOtp(string Otp,string MobileNo)
        {
            BaseRespons baseRespons = new BaseRespons();
            try
            {

                var result = await repositoryAsync.ValidateMobileOtp(Otp, MobileNo);
                if (result > 0)
                {
                    baseRespons.ResponseData = result;
                    baseRespons.StatusMessage = $"Otp Verified Successfully...!";
                    baseRespons.StatusCode = StatusCodes.Status200OK;
                    return Ok(baseRespons);
                }
                else
                {
                    baseRespons.StatusMessage = "Something is wrong...!";
                    baseRespons.StatusCode = StatusCodes.Status400BadRequest;
                    baseRespons.ResponseData = 0;
                    return Ok(baseRespons);
                }
            }
            catch (Exception ex)
            {
                baseRespons.StatusMessage = ex.Message;
                baseRespons.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseRespons);
            }
        }
    }
}
