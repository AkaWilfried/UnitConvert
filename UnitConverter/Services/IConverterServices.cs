using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitConverter.Model;
using UnitconverterData;

namespace UnitConverter.Services
{
    public interface IConverterServices
    {
        IList<Conversionrates> GetConversionrates();
        double Converter(EnumUnit unit, Sens sens, double value);
    }
}
