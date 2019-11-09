using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlobCloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;
using TableCloudStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount;

namespace Survivor.Services
{
    public class CloudStorageAccountProvider
    {

        private string ConnectionString = "get this key from steven";

        public BlobCloudStorageAccount BlobStorageAccount => BlobCloudStorageAccount.Parse(ConnectionString);

        public TableCloudStorageAccount TableStorageAccount => TableCloudStorageAccount.Parse(ConnectionString);

    }
}
