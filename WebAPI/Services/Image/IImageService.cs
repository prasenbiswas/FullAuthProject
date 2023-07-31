using Azure.Storage.Blobs;
using Common.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Image
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile file);
    }
}
