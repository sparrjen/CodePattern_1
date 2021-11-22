using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1.Interfaces
{
    public interface IAnimal 
    {

        //Properties
        public string AnimalName { get; set; }

        public bool IsCheckedIn { get; set; }

        public ICustomer Owner { get; set; } 

        public IStandardService StandardService { get; set; }

        public IWash Wash { get; set; }

        public IClawCutting ClawCutting { get; set; }

      
        // Funktioner
        public void CreateNewAnimal(List<IAnimal> animals, List<ICustomer> customers);

        public void SaveAnimal(IAnimal animal, List<IAnimal> animals);

        public void GetAnimals(List<IAnimal> animals);

        public void GetAnimalsWithOwner(List<IAnimal> animals);

        public void CheckInAnimal(List<IAnimal> animals, IAnimal animal);

        public void CheckOutAnimal(List<IAnimal> animals, IAnimal animal, IReceipt receipt, IStandardService standardService, IClawCutting clawCutting, IWash wash);

        public void GetAnimalsCeckedIn(List<IAnimal> animals);

        public void SetExtraServices(List<IAnimal> animals, IAnimal animal);

    }
}
