using geerirajwebapis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace geerirajwebapis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonDropdownController : ControllerBase
    {
        private readonly ICommanDropAsync commrepo;
        public CommonDropdownController(ICommanDropAsync commrepo)
        {
            this.commrepo = commrepo;
        }
        [HttpGet("GetProductTypeDrop")]
        public async Task<IActionResult> GetProductTypeDrop()
        {
            var result=await commrepo.GetProductTypeDrop();
            return Ok(result);
        }
    }
}
