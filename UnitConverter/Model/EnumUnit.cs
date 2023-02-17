using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConverter.Model
{
    public enum EnumUnit
    {
        INCH_TO_CENTIMETER = 1,
        FOOT_TO_METER = 2, 
        VERGE_TO_METER = 3,
        MILE_TO_KILOMETER = 4,
        TEMPERATURE = 5
    }

    public enum Sens
    {
        IMPERIAL_TO_METRIC = 0,
        METRIC_TO_IMPERIAL = 1
    }
}
