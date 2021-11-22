using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePattern_1.Interfaces
{
    public interface ISetServicePriceAndName
    {
        public void SetPrices(IStandardService standardService, IWash wash, IClawCutting clawCutting);

        public void SetName(IStandardService standardService, IWash wash, IClawCutting clawCutting);
    }
}
