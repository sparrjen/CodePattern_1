using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1.Interfaces
{
    public interface IStandardService
    { 
        public string Name { get; set; }

        public bool Status { get; set; }
        public decimal Price { get; set; }
    }
}
