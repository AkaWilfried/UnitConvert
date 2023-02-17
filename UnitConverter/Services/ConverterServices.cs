using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitConverter.Model;
using UnitconverterData;

namespace UnitConverter.Services
{
    public class ConverterServices: IConverterServices
    {
        private readonly UnitconverterDataContext context;
        public ConverterServices(UnitconverterDataContext context)
        {
            this.context = context;
        }
        /***
         * sens : 0 => Imperial to metric, 1 => Metric to Imperial
         * unit : From unit
         * value: Number to convert
         * */
        public double Converter(EnumUnit unit, Sens sens,  double value)
        {
            List<Conversionrates> rates = context.Conversionrates.ToList();
            if (rates == null || rates.Count == 0) return 0;
            Conversionrates rate = rates.Find(c => c.Id == (int)unit);
            if (rate == null) return 0;
            double returnvalue = 0;
            try
            {
                returnvalue = unit switch
                {
                    EnumUnit.TEMPERATURE => sens == 0 ? (value * rate.MetriqueEquivalent) + 32 : ((value - 32) * rate.Metricfactor),
                    _ => sens == 0 ? (value * rate.MetriqueEquivalent) : (value * rate.Metricfactor),
                };
            } catch
            {
                returnvalue = 0;
            }

            return returnvalue;
        }

        public IList<Conversionrates> GetConversionrates()
        {
            return context.Conversionrates.ToList();
        }
    }
}
