using EventPass.Domain.Interfaces.Services;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace EventPass.Infrastructure.Services
{
    public class QrService : IQrService
    {
        public byte[] GenerateQrCode(string path)
        {
            var generator = new QRCodeGenerator();

           
            QRCodeData data = generator.CreateQrCode(path, QRCodeGenerator.ECCLevel.Q);

           
            var qrCode = new QRCode(data);

            Bitmap bitmap = qrCode.GetGraphic(10);
            var stream = new MemoryStream();
            {
                
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
