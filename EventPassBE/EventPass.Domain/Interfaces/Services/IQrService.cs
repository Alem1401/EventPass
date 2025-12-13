using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Services
{
    public interface IQrService
    {
        public byte[] GenerateQrCode(string path);
    }
}
