using Spells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spells.Services
{
    public class SpellsDatabase
    {
        private List<SpellModel> spells = new List<SpellModel>();

        public bool Any()
        {
            return spells.Any();
        }

        public int Count()
        {
            return spells.Count();
        }

        public void Add(string spell)
        {
            this.spells.Add(new SpellModel() { Name = spell });
        }

        public SpellModel Get(int index)
        {
            return spells[index];
        }

        public void RemoveAt(int index)
        {
            spells.RemoveAt(index);
        }

        public void Mix(string first, string second)
        {
            Add(first + second);
        }
    }
}
