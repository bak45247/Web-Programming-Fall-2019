using BlobCloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;
using TableCloudStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount;

namespace Survivor.Services
{
    public interface ICloudStorageAccountProvider
    {
        BlobCloudStorageAccount BlobStorageAccount { get; }

        TableCloudStorageAccount TableStorageAccount { get; }
    }
}
