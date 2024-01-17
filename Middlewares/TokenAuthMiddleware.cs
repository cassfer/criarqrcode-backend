using CriarQrCode_backend.Model.Enums;
using CriarQrCode_backend.Model.Exceptions;
using System.Net;
using System.Text.Json;

namespace CriarQrCode_backend.Middleware
{

    public class TokenAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token = Environment.GetEnvironmentVariable("API_AUTH_KEY");

        public TokenAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var tokenRequest = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(tokenRequest))
                {
                    tokenRequest = tokenRequest.Split(" ")[1];
                    if (_token != tokenRequest)
                    {
                        throw new AuthException(
                            (int) HttpStatusCode.Unauthorized,
                            Constants.Texto.TokenIncorrect,
                            ErrorEnumModel.AutenticacaoInvalida
                        );

                    }
                    await _next(context);
                }
                else
                {
                    throw new AuthException(
                        (int)HttpStatusCode.Unauthorized,
                        Constants.Texto.TokenEmptyOrNull,
                        ErrorEnumModel.AutenticacaoVazia
                    );
                }
            }
            catch (AuthException authEx)
            {
                var response = JsonSerializer.Serialize(authEx.ErrorResponse);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(response);
            }

        }
    }

    public static class TokenAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenAuthMiddleware>();
        }
    }
}
