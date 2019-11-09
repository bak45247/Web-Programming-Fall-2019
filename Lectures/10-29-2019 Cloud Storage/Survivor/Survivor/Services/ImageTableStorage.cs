using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public class ImageTableStorage
    {
        // Everything related to blobs and storage

        private readonly CloudStorageAccountProvider cloudStorageAccountProvider;
        private readonly UserNameProvider userNameProvider;
        private readonly CloudBlobContainer blobContainer;
        private readonly CloudTable table;

        public ImageTableStorage(CloudStorageAccountProvider cloudStorageAccountProvider, UserNameProvider userNameProvider)
        {
            this.cloudStorageAccountProvider = cloudStorageAccountProvider;
            this.userNameProvider = userNameProvider;

            var blobClient = this.cloudStorageAccountProvider.BlobStorageAccount.CreateCloudBlobClient();
            this.blobContainer = blobClient.GetContainerReference(this.userNameProvider.UserName);

            var tableClient = this.cloudStorageAccountProvider.TableStorageAccount.CreateCloudTableClient();
            this.table = tableClient.GetTableReference(this.userNameProvider.UserName);
        }

        public async Task StartupAsync()
        {
            await this.blobContainer.CreateIfNotExistsAsync();
            await this.table.CreateIfNotExistsAsync();
        }

        public string GetUploadSas(string id)
        {
            // this code gives access to the entire blob container. wrong for assignment 9, assignment 9 is to limit access to the 'id' container

            // this is what we use for assignment 9
            // this.blobContainer.GetBlobReference("File name").GetSharedAccessSignature()

            return this.blobContainer.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Add | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            });
        }
    }
}
