using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using SampleCarManagementApp.Application.Exceptions;
using SampleCarManagementApp.Application.Wrappers;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = ApiResponse<string>.Fail(error.Message);

                switch (error)
                {
                    case ApiException e:
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            responseModel.ErrorTypes = e.Exceptions;
                        }
                        break;
                    case ValidationException e:
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            responseModel.Errors = e.Errors;
                        }
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}