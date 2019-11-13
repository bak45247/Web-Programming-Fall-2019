using SurvivorRefactor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivorRefactor.Entities.V1U1
{
    public class ValueEntity
    {
        [Required]
        [MinLength(10)]
        public string Message { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ValueModel ToModel()
        {
            ValueModel model = new ValueModel();
            model.Name = this.Name;
            model.Message = this.Message;

            return model;
        }
    }
}
