using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataValidator.Models
{
    class InvalidUserDataException : Exception
    {
        public InvalidUserDataException(string message)
            : base(message)
        {

        }
    }
}
