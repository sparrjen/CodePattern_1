using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1.Interfaces
{
    public interface IReceipt
    {
        public IStandardService StandardService { get; set; }
        public IWash Wash { get; set; }
        public IClawCutting ClawCutting { get; set; }
        public decimal TotalCost { get; set; }

        public void ShowReceipt(IStandardService standardService, IClawCutting clawCutting, IWash wash, List<IAnimal> animals, IAnimal animal);
    }
}
