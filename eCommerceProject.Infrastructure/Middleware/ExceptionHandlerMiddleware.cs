using eCommerceProject.Application.Services.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Infrastructure.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await _next(context);
			}
			catch (DbUpdateException ex)
			{
                var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionHandlerMiddleware>>();
                if (ex.InnerException is SqlException innerException)
                {
                    logger.LogError(innerException, $"Sql Database error occurred: {innerException.Message}");
                    switch (innerException.Number)
                    {
                        
                        case 515:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Bad Request: Cannot insert null value into a non-nullable column.");
                            break;
                        case 547:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Bad Request: Foreign key constraint violation.");
                            break;
                        case 2601:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("Conflict occurred: Unique index violation.");
                            break;
                        case 2617:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync("Conflict occurred: Duplicate key error.");
                            break;
                        default: 
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync("An unexpected database error occurred.");
                            break;
                    }
                }
                else
                {
                    logger.LogError(ex, $"EF error occurred: {ex.Message}");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An unexpected database error occurred.");
                }
            }
            catch(Exception ex)
            {
                var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionHandlerMiddleware>>();
                logger.LogError(ex, $"Unknown error occurred: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred." + ex.Message);
            }
        }
    }
}
