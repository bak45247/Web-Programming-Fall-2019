using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_5.Models;

namespace Assignment_5.Services
{
    public class SpellsDatabase
    {
        private List<SpellsModel> spells = new List<SpellsModel>();

        public void Add(string spell)
        {
            this.spells.Add(new SpellsModel() { Name = spell });
        }

        public SpellsModel Get(int index)
        {
            return spells[index];
        }

        public bool Any()
        {
            return spells.Any();
        }

        public int Count()
        {
            return spells.Count();
        }

        public void RemoveAt(int index)
        {
            spells.RemoveAt(index);
        }
    }
}
