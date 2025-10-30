using eCommerceProject.Application.DTOs.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Validations
{
    public interface IValidationService
    {
        Task<ServiceResponse> ValidateAsync<T>(T model, IValidator<T> validator);
    }

    public class ValidationService : IValidationService
    {
        public async Task<ServiceResponse> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var _validationResult = await validator.ValidateAsync(model);
            if (!_validationResult.IsValid)
            {
                var errors = _validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string stringErrors = string.Join("; ", errors);
                return new ServiceResponse { Success = false, Message = stringErrors };
            }
            return new ServiceResponse{ Success = true, Message = "Validation succeeded."};
        }
    }
}
