﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gargoyles.Model
{
    public class GargoyleModel
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public DateTime Updated { get; set; }
        

        public string ETag()
        {
            return this.Updated.ToString();
        }
    }
}
