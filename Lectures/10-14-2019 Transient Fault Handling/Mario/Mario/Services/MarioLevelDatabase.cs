using Mario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mario.Services
{
    public class MarioLevelDatabase
    {
        private List<MarioLevelModel> marioLevels = new List<MarioLevelModel>();

        public MarioLevelDatabase()
        {
            marioLevels.Add(new MarioLevelModel() { Name = "Bowser's Castle", World = 8 });
            marioLevels.Add(new MarioLevelModel() { Name = "Underground", World = 1 });
        }

        public bool Add(MarioLevelModel marioLevel)
        {
            marioLevels.Add(marioLevel);
            return true;
        }

        public bool Add(MarioLevelModel marioLevel, int id)
        {
            if (id < 0 || id > marioLevels.Count)
            {
                return false;
            }

            marioLevels[id] = marioLevel;

            return true;
        }

        public IEnumerable<MarioLevelModel> Get()
        {
            return marioLevels;
        }

        public MarioLevelModel Get(int id)
        {
            return marioLevels[id];
        }

        public bool Delete(int id)
        {
            marioLevels.RemoveAt(id);
            return true;
        }
    }
}
