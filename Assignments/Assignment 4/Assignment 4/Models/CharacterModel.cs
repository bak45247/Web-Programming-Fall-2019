using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_4.Models
{
    public class CharacterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Character { get; set; }
        public List<string> Views { get; set; }

        public CharacterModel()
        {
            this.Views = new List<string>();
        }
    }
}
