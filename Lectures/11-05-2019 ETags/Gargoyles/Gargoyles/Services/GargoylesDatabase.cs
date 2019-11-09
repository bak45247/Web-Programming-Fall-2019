using Gargoyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gargoyles.Services
{
    public class GargoylesDatabase
    {
        private Dictionary<string, GargoylesModel> Gargoyles = new Dictionary<string, GargoylesModel>();

        public GargoylesModel Get(string index)
        {
            return this.Gargoyles[index];
        }

        public void AddOrReplace(GargoylesModel model)
        {
            model.Updated = DateTime.UtcNow;
            this.Gargoyles[model.Name] = model;
        }

        public void Updated(GargoylesModel model)
        {
            var modelToUpdate = this.Gargoyles[model.Name];

            if (!string.IsNullOrWhiteSpace(model.Color))
            {
                modelToUpdate.Updated = DateTime.UtcNow;
                modelToUpdate.Color = model.Color;
            }
        }
    }
}
