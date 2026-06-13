using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Application.Interface
{
    public interface IConversionService
    {
        double Convert(string category, string fromUnit, string toUnit, double value);
    }
}
