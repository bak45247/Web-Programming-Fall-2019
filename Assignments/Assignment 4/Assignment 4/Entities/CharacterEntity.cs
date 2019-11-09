using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_4.Entities
{
    public class CharacterEntity
    {
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Character { get; set; }
        public int Views { get; internal set; }

        public CharacterModel ToModel()
        {
            return new CharacterModel()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Character = this.Character
            };
        }

        // we always need a no-args constructor in entity classes
        public CharacterEntity()
        {

        }

        public CharacterEntity(CharacterModel characterModel)
        {
            this.FirstName = characterModel.FirstName;
            this.LastName = characterModel.LastName;
            this.Character = characterModel.Character;
            this.Views = characterModel.Views.Count();
        }
    }
}
