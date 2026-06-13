using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Application.Exceptions
{
    public class InvalidConversionException : Exception
    {
        public InvalidConversionException(string message) : base(message)
        {
        }
    }
}
