using eCommerceProject.Domain.Entities.Cart;
using eCommerceProject.Domain.Interfaces.Cart;
using eCommerceProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Infrastructure.Repositories.Cart
{
    public class PaymentMethodRepository(AppDbContext context) : IPaymentMethod
    {
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            return await context.PaymentMethods.AsNoTracking().ToListAsync();
        }
    }
}
