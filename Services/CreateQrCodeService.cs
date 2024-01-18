using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace CriarQrCode_backend.Services
{
    public class CreateQrCodeService
    {
        public string createQrCodeFromText(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);

            return Convert.ToBase64String(qrCodeAsBitmapByteArr);
        }

    }
}
