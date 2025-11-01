using eCommerceProject.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Domain.Interfaces.Cart
{
    public interface IPaymentMethod
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods(); 
    }
}
