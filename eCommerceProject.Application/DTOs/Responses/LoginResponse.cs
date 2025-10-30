using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.DTOs.Responses
{
    public record LoginResponse(bool Success = false, string Message = null!, string Token = null!, string refreshToken = null!);
}
