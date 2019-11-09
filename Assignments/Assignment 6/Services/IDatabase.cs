using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface IDatabase
    {

        int Size { get; }

        void AddString(string key, string newData);
        IEnumerable<string> GetData(string key);
        void DeleteAll();
    }
}
