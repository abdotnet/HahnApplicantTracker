using Hahn.ApplicatonProcess.December2020.Domain.Infrastructure;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Hahn.ApplicatonProcess.December2020.Web.Middlware
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string Get(this HttpContext context, Exception ex)
        {
            var responseModel = new ApiResponse();

            try
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                if (ex.GetType() == typeof(SecurityTokenValidationException))
                {
                    responseModel.Message = "Invalid token";
                    responseModel.Status = ApplicationStatusCode.InvalidToken;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SecurityTokenInvalidIssuerException))
                {
                    responseModel.Message = "Invalid issuer";
                    responseModel.Status = ApplicationStatusCode.InvalidIssuer;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SecurityTokenExpiredException))
                {
                    responseModel.Message = "Token expired";
                    responseModel.Status = ApplicationStatusCode.TokenExpired;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(ModelValidationException))
                {
                    ModelValidationException? error = ex as ModelValidationException;
                    responseModel.Status = ApplicationStatusCode.ModelValidation;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(ArgumentNullException))
                {
                    ModelValidationException error = ex as ModelValidationException;
                    responseModel.Status = ApplicationStatusCode.ModelValidation;
                    responseModel.Message = "Parameter passed is incorrect.";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(AlreadyExistException))
                {
                    responseModel.Status = ApplicationStatusCode.AlreadyExist;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(NotFoundException))
                {
                    responseModel.Status = ApplicationStatusCode.NotFound;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else if (ex.GetType() == typeof(NotActiveException))
                {
                    responseModel.Status = ApplicationStatusCode.NotActive;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(BadRequestException))
                {
                    responseModel.Status = ApplicationStatusCode.BadRequest;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(VerificationCodeException))
                {
                    responseModel.Status = ApplicationStatusCode.VerificationCode;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(PasswordException))
                {
                    responseModel.Status = ApplicationStatusCode.PasswordError;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(SessionExpiredException))
                {
                    responseModel.Status = ApplicationStatusCode.SessionExpired;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else if (ex.GetType() == typeof(InvalidOperationException))
                {
                    responseModel.Status = ApplicationStatusCode.InvalidOperation;
                    responseModel.Message = ex.Message; // "Invalid Request";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                }
                else if (ex.GetType() == typeof(LoginException))
                {
                    responseModel.Status = ApplicationStatusCode.LoginOperation;
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseModel.Status = ApplicationStatusCode.GenericError; 
                    responseModel.Message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                return JsonConvert.SerializeObject(responseModel);
            }
            catch (Exception _ex)
            {
                responseModel.Status = ApplicationStatusCode.GenericError;
                responseModel.Message = _ex.Message != null ? _ex.Message : "Please contact the administrator";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return JsonConvert.SerializeObject(responseModel);
            }
        }
    }
}

