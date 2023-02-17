using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitconverterData;

namespace UnitConverter.Helpers
{
    public static class DataChecker
    {
        public static IHost Seed(this IHost host)
        {
            using IServiceScope scope = host.Services.CreateScope();
            using UnitconverterDataContext context = scope.ServiceProvider.GetRequiredService<UnitconverterDataContext>();
            try
            {
                context.Database.EnsureCreated();
                AddRate(context);
            }
            catch
            {
                throw;
            }
            return host;
        }
        /***
         * AddRate method is use to insert data to table when table has not data
         * 
         */
        private static void AddRate(UnitconverterDataContext context)
        {
            Conversionrates rates = context.Conversionrates.FirstOrDefault();
            if (rates != null) return;
            /***
             * Add data on table if not exist data
             * */
            context.Conversionrates.Add(new Conversionrates
            {
               Id = 1,
               Unit = "inch",
               MetriqueEquivalent = 2.54,
               Equivalentunit = "centimeter",
               Metricfactor = 0.3937

            });

            context.Conversionrates.Add(new Conversionrates
            {
                Id = 2,
                Unit = "foot",
                MetriqueEquivalent = 0.3048,
                Equivalentunit = "meter",
                Metricfactor = 0.3937

            });

            context.Conversionrates.Add(new Conversionrates
            {
                Id = 3,
                Unit = "verge",
                MetriqueEquivalent = 0.9144,
                Equivalentunit = "meter",
                Metricfactor = 1.094

            });

            context.Conversionrates.Add(new Conversionrates
            {
                Id = 4,
                Unit = "mile",
                MetriqueEquivalent = 1.6093,
                Equivalentunit = "kilometer",
                Metricfactor = 0.6214

            });

            context.Conversionrates.Add(new Conversionrates
            {
                Id = 5,
                Unit = "Fahrenheit imp (°F)",
                MetriqueEquivalent = 1.8,
                Equivalentunit = "Fahrenheit metric (°F)",
                Metricfactor = 0.5555

            }); ;


            context.SaveChanges();
        }
    }
}
