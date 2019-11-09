using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment7.Entities
{
    public class MoveEntity
    {
        public string Message;
        public string Next;

        public MoveEntity()
        {
        }

        public MoveEntity(string message)
        {
            this.Message = message;
        }
    }
}
