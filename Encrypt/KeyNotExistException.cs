using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    public  class KeyNotExistException: Exception
    {
        public KeyNotExistException()
        {
                
        }
      
        public KeyNotExistException(string message, Exception inner=null)
        : base(message, inner)
        {
        }
    }
}
