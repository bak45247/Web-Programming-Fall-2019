using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    public class PotionsDatabase
    {
        private List<PotionsModel> potions = new List<PotionsModel>();

        public void Add(string ingredient)
        {
            this.potions.Add(new PotionsModel() { Name = ingredient });
        }

        public void Add(string first, string second)
        {
            Random random = new Random();
            var count = first.Count() + second.Count();
            string ingredient = "";
            for (int i = 0; i < count; i++)
            {
                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
                {
                    int insert = random.Next(2);
                    if (insert == 0)
                    {
                        ingredient = ingredient.Insert(i, first.Substring(0, 1));
                        first = first.Remove(0, 1);
                    }
                    else
                    {
                        ingredient = ingredient.Insert(i, second.Substring(0, 1));
                        second = second.Remove(0, 1);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(first))
                    {
                        ingredient = ingredient.Insert(i, second.Substring(0, 1));
                        second = second.Remove(0, 1);
                    }
                    else if (string.IsNullOrEmpty(second))
                    {
                        ingredient = ingredient.Insert(i, first.Substring(0, 1));
                        first = first.Remove(0, 1);
                    }
                }
            }

            this.potions.Add(new PotionsModel() { Name = ingredient });
        }

        public PotionsModel Get(int index)
        {
            return potions[index];
        }

        public bool Any()
        {
            return potions.Any();
        }

        public int Count()
        {
            return potions.Count();
        }

        public void RemoveAt(int index)
        {
            potions.RemoveAt(index);
        }
    }
}
