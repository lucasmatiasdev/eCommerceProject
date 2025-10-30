using AutoMapper;
using eCommerceProject.Application.DTOs.Identity;
using eCommerceProject.Application.DTOs.Responses;
using eCommerceProject.Application.Services.Interfaces.Authentication;
using eCommerceProject.Application.Services.Interfaces.Logging;
using eCommerceProject.Application.Validations;
using eCommerceProject.Domain.Entities.Identity;
using eCommerceProject.Domain.Interfaces.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Services.Implementations.Authentication
{
    public class AuthenticationService(ITokenManagement tokenManagement, IUserManagement userManagement,
        IRoleManagement roleManagement, IAppLogger<AuthenticationService> logger, IMapper mapper, 
        IValidator<CreateUser> createUserValidator, IValidator<LoginUser> loginUserValidator,
        IValidationService validationService) : IAuthenticationService
    {
        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {
            var _validationResult = await validationService.ValidateAsync(user, createUserValidator);
            if(!_validationResult.Success) return _validationResult;

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.UserName = user.Email;
            mappedModel.PasswordHash = user.Password;

            var result = await userManagement.CreateUser(mappedModel);
            if (!(bool)result) return new ServiceResponse { Message = "User creation failed.", Success = false };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var users = await userManagement.GetAllUsers();
            bool assignedResult = (bool)await roleManagement.AddUserToRole(_user!, users!.Count() > 1 ? "User" : "Admin");
            if (!assignedResult)
            {
                int removeUserResult = await userManagement.RemoveUserByEmail(user.Email);
                if (removeUserResult <= 0)
                {
                    logger.LogError(new Exception($"User with email: {user.Email} failed to be removed as a result of role" +
                        $"assign"), "User could not be assigned role");
                    return new ServiceResponse { Message = "User creation failed.", Success = false };
                }
            }
            return new ServiceResponse { Message = "User created successfully.", Success = true };

            //Verify email process to be added later
        }

        public async Task<LoginResponse> LoginUser(LoginUser user)
        {
            var _validationResult = await validationService.ValidateAsync(user, loginUserValidator);
            if(!_validationResult.Success) return new LoginResponse { Message = _validationResult.Message, Success = false };

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;

            bool loginResult = (bool)await userManagement.LoginUser(mappedModel);
            if (!loginResult) return new LoginResponse { Message = "Invalid email or password.", Success = false };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(_user!.Email!);

            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            bool? userTokenCheck = await tokenManagement.ValidateRefreshToken(refreshToken);

            int saveTokenResult = 0;
            if ((bool)userTokenCheck) saveTokenResult = await tokenManagement.UpdateRefreshToken(_user.Id, refreshToken);
            else saveTokenResult = await tokenManagement.AddRefreshToken(_user.Id, refreshToken);

            return saveTokenResult > 0
                ? new LoginResponse { Message = "Login successful.", Success = true, Token = jwtToken, refreshToken = refreshToken }
                : new LoginResponse { Message = "Login failed.", Success = false };
        }

        public async Task<LoginResponse> ReviveToken(string refreshToken)
        {
            bool validateTokenResult = (bool)await tokenManagement.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult) return new LoginResponse { Message = "Invalid refresh token.", Success = false };

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            AppUser? user = await userManagement.GetUserById(userId);
            var claims = await userManagement.GetUserClaims(user!.Email!);

            string newJwtToken = tokenManagement.GenerateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse
            {
                Success = true,
                Token = newJwtToken,
                refreshToken = newRefreshToken
            };
        }
    }
}
