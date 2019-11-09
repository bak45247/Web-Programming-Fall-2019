using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuscotopia.Entities
{
    public class WorkEntity
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public int Data { get; set; }

        public WorkEntity()
        {

        }

        public WorkEntity(int type)
        {
            Random random = new Random();
            if(type == 0)
            {
                this.Type = "Carry";
                this.Message = "Peasants are carrying bricks";
            }
            else if(type == 1)
            {
                this.Type = "Build";
                this.Message = "Peasants are building buildings";
                this.Data = random.Next(1, 6);
            }
            else
            {
                this.Type = "Survey";
                this.Message = "Good job peasants";
                this.Data = random.Next(500, 1001);
            }
        }
    }
}
