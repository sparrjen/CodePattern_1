using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1.Interfaces
{
    public interface ICustomer : IUser
    {
 
        public List<IAnimal> Animals { get; set; }

        public void SaveCustomers(ICustomer customer, List<ICustomer> customers);

        public void GetCustomers(List<ICustomer> customers);

        public void CreateNewCustomer(List<ICustomer> customers);
    }
}
