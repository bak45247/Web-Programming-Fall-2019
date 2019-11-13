using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivorRefactor.Entities.V1U0
{
    public class ValueEntity
    {
        [Required]
        [MinLength(10)]
        public string Message { get; set; }
    }
}
