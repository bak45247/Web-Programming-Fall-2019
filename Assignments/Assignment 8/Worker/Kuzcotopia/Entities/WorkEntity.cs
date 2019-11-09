using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuscotopia.Entities
{
    public class WorkEntity
    {
        [MinLength(1)]
        [Required]
        public string Type { get; set; }

        [MinLength(1)]
        [Required]
        public string Message { get; set; }
        public int Data { get; set; }
    }
}
