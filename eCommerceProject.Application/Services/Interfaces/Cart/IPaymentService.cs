using eCommerceProject.Application.DTOs.Cart;
using eCommerceProject.Application.DTOs.Responses;
using eCommerceProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Services.Interfaces.Cart
{
    public interface IPaymentService
    {
        Task<ServiceResponse> Pay(decimal totalAmount, IEnumerable<Product> cartProducts, IEnumerable<ProcessCart> carts);
    }
}
