using eCommerceProject.Application.Services.Interfaces.Cart;
using eCommerceProject.Domain.Entities.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentMethodService paymentMethodService) : ControllerBase
    {
        [HttpGet("payment-methods")]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        { 
            var methods = await paymentMethodService.GetPaymentMethods();
            return !methods.Any() ? (ActionResult<IEnumerable<PaymentMethod>>)NotFound() : (ActionResult<IEnumerable<PaymentMethod>>)Ok(methods);
        }
    }
}
