using CriarQrCode_backend.Model.Enums;

namespace CriarQrCode_backend.Model
{
    public class ErrorResponseModel
    {
        public int statusCode { get; }
        public string message { get; }
        public ErrorEnumModel codeErrorStatus { get; }

        public ErrorResponseModel(int statusCode, string message, ErrorEnumModel codeErrorStatus)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.codeErrorStatus = codeErrorStatus;
        }
    }
}
