using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitConverter.Model;
using UnitConverter.Services;
using UnitconverterData;

namespace UnitConverter.Controllers
{
    public class ConverterController : ControllerBase
    {
        private readonly UnitconverterDataContext context;
        private readonly IConverterServices converterServices;
        public ConverterController(UnitconverterDataContext _context)
        {
            context = _context;
            converterServices = new ConverterServices(context);
        }

        [HttpGet]
        [Route("api/rates")]
        public IList<Conversionrates> GetConversionrates()
        {
            return converterServices.GetConversionrates();
        }

        [HttpPost]
        [Route("api/convert")]
        public double Converter([FromBody] RateInput rateInput)
        {
            return converterServices.Converter((EnumUnit) rateInput.Unit, (Sens) rateInput.Sens, rateInput.Value);
        }
    }
}
