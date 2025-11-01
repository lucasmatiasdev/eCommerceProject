using AutoMapper;
using eCommerceProject.Application.DTOs.Cart;
using eCommerceProject.Application.Services.Interfaces.Cart;
using eCommerceProject.Domain.Interfaces.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Services.Implementations.Cart
{
    public class PaymentMethodService(IPaymentMethod paymentMethod, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods()
        {
            var methods = await paymentMethod.GetPaymentMethods();
            if (!methods.Any()) return [];
            return mapper.Map<IEnumerable<GetPaymentMethod>>(methods);
        }
    }
}
