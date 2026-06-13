using UnitConversion.Application.Exceptions;
using UnitConversion.Application.Interface;
using UnitConversion.Infrastructure.Data;

namespace UnitConversion.Infrastructure.Service
{
    public class ConversionService : IConversionService
    {
        public double Convert(string category, string fromUnit, string toUnit, double value)
        {
            if (category.Equals("temperature", StringComparison.OrdinalIgnoreCase))
            {
                return ConvertTemperature(fromUnit, toUnit, value);
            }

            if (!UnitRepository.UnitsDCT.ContainsKey(category)) throw new InvalidConversionException($"Category '{category}' not found.");

            var units = UnitRepository.UnitsDCT[category];

            if (!units.ContainsKey(fromUnit)) throw new InvalidConversionException($"Unit '{fromUnit}' not found.");

            if (!units.ContainsKey(toUnit)) throw new InvalidConversionException($"Unit '{toUnit}' not found.");

            double baseValue = value * units[fromUnit];

            return baseValue / units[toUnit];
        }

        private static double ConvertTemperature(string fromUnit, string toUnit, double value)
        {
            if (fromUnit.Equals(toUnit, StringComparison.OrdinalIgnoreCase))
            {
                return value;
            }

            if (fromUnit.Equals("celsius", StringComparison.OrdinalIgnoreCase) && toUnit.Equals("fahrenheit", StringComparison.OrdinalIgnoreCase))
            {
                return (value * 9 / 5) + 32;
            }

            if (fromUnit.Equals("fahrenheit", StringComparison.OrdinalIgnoreCase) && toUnit.Equals("celsius", StringComparison.OrdinalIgnoreCase))
            {
                return (value - 32) * 5 / 9;
            }

            if (fromUnit.Equals("celsius", StringComparison.OrdinalIgnoreCase) && toUnit.Equals("kelvin", StringComparison.OrdinalIgnoreCase))
            {
                return value + 273.15;
            }

            if (fromUnit.Equals("kelvin", StringComparison.OrdinalIgnoreCase) && toUnit.Equals("celsius", StringComparison.OrdinalIgnoreCase))
            {
                return value - 273.15;
            }

            throw new InvalidConversionException("Unsupported temperature conversion.");

        }
    }
}
