using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment7.Services
{
    public interface IMarioService
    {
        Task<string> GetAsync(string move);
    }
}
