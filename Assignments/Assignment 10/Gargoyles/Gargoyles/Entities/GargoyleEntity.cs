using Gargoyles.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Gargoyles.Entities
{
    public class GargoyleEntity
    {
        public GargoyleEntity()
        {

        }

        public GargoyleEntity(GargoyleModel model)
        {
            this.Name = model.Name;
            this.Color = model.Color;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Color { get; set; }

        public GargoyleModel ToModel()
        {
            return new GargoyleModel()
            {
                Name = this.Name,
                Color = this.Color
            };
        }
    }
}
