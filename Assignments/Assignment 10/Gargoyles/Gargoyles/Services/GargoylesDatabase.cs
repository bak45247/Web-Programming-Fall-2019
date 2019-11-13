using Gargoyles.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gargoyles.Services
{
    public class GargoylesDatabase
    {

        private Dictionary<string, GargoyleModel> gargoyles = new Dictionary<string, GargoyleModel>();

        public GargoyleModel Get(string index)
        {
            return this.gargoyles[index];
        }

        public void AddOrReplace(GargoyleModel model)
        {
            model.Updated = DateTime.UtcNow;
            this.gargoyles[model.Name] = model;
        }

        public GargoyleModel Update(string index, GargoyleModel model)
        {
            var modelToUpdate = this.gargoyles[index];

            // true if null
            // true if ""
            // true if "    "
            if (!string.IsNullOrWhiteSpace(model.Color))
            {
                modelToUpdate.Updated = DateTime.UtcNow;
                modelToUpdate.Color = model.Color;
            }

            return modelToUpdate;
        }
    }
}
