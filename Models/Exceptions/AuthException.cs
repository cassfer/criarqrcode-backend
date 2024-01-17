using CriarQrCode_backend.Model.Enums;

namespace CriarQrCode_backend.Model.Exceptions
{
    public class AuthException : Exception
    {
        public ErrorResponseModel ErrorResponse { get; }
        public AuthException(int statusCode, string message, ErrorEnumModel codeErrorStatus) : base(message)
        {
            this.ErrorResponse = new ErrorResponseModel(statusCode, message, codeErrorStatus);
        }
    }
}
