using Mario.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mario.Entities
{
    public class MarioLevelEntity
    {
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        [Range(1, 10)]
        public int World { get; set; }

        public MarioLevelModel ToModel()
        {
            return new MarioLevelModel()
            {
                Name = this.Name,
                World = this.World
            };
        }

        public MarioLevelEntity()
        {

        }

        public MarioLevelEntity(MarioLevelModel model)
        {
            this.Name = model.Name;
            this.World = model.World;
        }
    }
}
