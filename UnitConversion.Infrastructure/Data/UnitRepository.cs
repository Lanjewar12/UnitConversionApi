using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Infrastructure.Data
{
    public class UnitRepository
    {
        public static readonly Dictionary<string, Dictionary<string, double>> UnitsDCT = new(StringComparer.OrdinalIgnoreCase)
        {
            ["length"] = new(StringComparer.OrdinalIgnoreCase)
            {
                ["meter"] = 1,
                ["kilometer"] = 1000,
                ["centimeter"] = 0.01,
                ["foot"] = 0.3048,
                ["inch"] = 0.0254
            },

            ["weight"] = new(StringComparer.OrdinalIgnoreCase)
            {
                ["kilogram"] = 1,
                ["gram"] = 0.001,
                ["pound"] = 0.453592,
                ["ounce"] = 0.0283495
            }
        };
    }
}
