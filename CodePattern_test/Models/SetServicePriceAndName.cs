using CodePattern_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_1.Models
{
    public class SetServicePriceAndName : ISetServicePriceAndName
    {
        public void SetPrices(IStandardService standardService, IWash wash, IClawCutting clawCutting)
        {
            standardService.Price = 299;
            wash.Price = 99;
            clawCutting.Price = 99;
        }

        public void SetName(IStandardService standardService, IWash wash, IClawCutting clawCutting)
        {
            standardService.Name = "Dagpassning";
            wash.Name = "Tvätt";
            clawCutting.Name = "Kloklippning";
        }

    }
}
