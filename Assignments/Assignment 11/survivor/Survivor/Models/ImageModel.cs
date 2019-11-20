using Microsoft.Azure.Cosmos.Table;
using Survivor.Entities;

namespace Survivor.Models
{
    public class ImageModel : TableEntity
    {
        public ImageModel(string userName, string name)
        {
            this.UserName = userName;
            this.Name = name;
        }

        public ImageModel(string userName, string name, string description)
        {
            this.UserName = userName;
            this.Name = name;
            this.Description = description;
        }

        public ImageModel()
        {

        }

        public string UserName
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }

        public string Id {
            get { return this.RowKey; }
            set { this.RowKey = value; }
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public bool UploadComplete { get; set; }

        public Entities.V1U0.ImageEntity ToEntity()
        {
            return new Entities.V1U0.ImageEntity()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
        public Entities.V1U1.ImageEntity ToEntityV1U1()
        {
            return new Entities.V1U1.ImageEntity()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
