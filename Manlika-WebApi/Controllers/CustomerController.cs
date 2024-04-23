using Manlika_WebApi.Model;
using Manlika_WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manlika_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //-----------------------------------------------------------------//
        //-----------------1. ทำ Web API โดยใช้ .net and C# -----------------//
        //-----------------------------------------------------------------//

        [Authorize]
        [Route("GetCustomerOrderSummary")]
        [HttpGet]
        public ActionResult<List<CustomerOrderSummary>> GetCustomerOrderSummary()
        {
            var cusSum = _customerService.GetCustomerOrderSummary();

            return Ok(cusSum);
        }
    }
}
