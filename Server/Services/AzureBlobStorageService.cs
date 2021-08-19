using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace KnowledgeBase.Server.Services
{
    public class AzureBlobStorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly AzureStorageSetting _azureStorageSetting;

        public AzureBlobStorageService(BlobServiceClient blobServiceClient, IOptions<AzureStorageSetting> options)
        {
            _blobServiceClient = blobServiceClient;
            _azureStorageSetting = options.Value;
        }

        public string GetProtectedUrl(string containerName, string blobName, DateTimeOffset expireDate)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(Path.GetFileName(blobName));
            var sasToken = blob.GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, expireDate);

            return sasToken.AbsoluteUri;
        }

        public async Task RemoveBlobAsync(string containerName, string blobName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(Path.GetFileName(blobName));
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> SaveBlobAsync(string containerName, IFormFile file)
        {
            if (file == null)
                return null;

            var fileName = file.FileName;
            var extension = Path.GetExtension(fileName);
            var newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}-{Guid.NewGuid()}{extension}";

            using var stream = file.OpenReadStream();
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(newFileName);
            await blob.UploadAsync(stream);

            return $"{_azureStorageSetting.AccountUrl}/{containerName}/{newFileName}";
        }
    }
}
