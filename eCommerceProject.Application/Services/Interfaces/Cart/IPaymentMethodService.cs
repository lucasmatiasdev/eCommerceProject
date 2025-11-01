using eCommerceProject.Application.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Services.Interfaces.Cart
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods();
    }
}
