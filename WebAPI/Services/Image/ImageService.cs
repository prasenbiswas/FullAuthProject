using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Image
{
    public class ImageService : IImageService
    {
        private readonly AzureOptions _azureOptions;
        public ImageService(IOptions<AzureOptions> azureOptions)
        {
            _azureOptions = azureOptions.Value;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            try
            {

                var fileExtension = Path.GetExtension(file.FileName);
                using MemoryStream fileUploadStream = new MemoryStream();
                file.CopyTo(fileUploadStream);
                fileUploadStream.Position = 0;
                BlobContainerClient blobContainerClient = new BlobContainerClient(
                    _azureOptions.StorageConnection,
                    _azureOptions.Container);
                var uniqueName = Guid.NewGuid().ToString() + fileExtension;
                BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueName);
                blobClient.Upload(fileUploadStream, new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = "image/bitmap",
                    }
                }, cancellationToken: default);
                return ("Succefully uploaded");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //string imageFullPath = null;
            //if (file == null)
            //{
            //    return null;
            //}
            //try
            //{

            //    if (CloudStorageAccount.TryParse(_azureOptions.StorageConnection, out CloudStorageAccount cloudStorageAccount))
            //    {

            //        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            //        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_azureOptions.Container);
            //        await cloudBlobContainer.CreateIfNotExistsAsync();
            //        await cloudBlobContainer.SetPermissionsAsync(
            //            new BlobContainerPermissions
            //            {
            //                PublicAccess = BlobContainerPublicAccessType.Blob
            //            }
            //            );
            //        var filename = Guid.NewGuid() + file.FileName;
            //        CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
            //        await blockBlob.UploadFromStreamAsync(file.OpenReadStream());


            //        imageFullPath = blockBlob.Uri.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            //return imageFullPath;

        }
    }
}
