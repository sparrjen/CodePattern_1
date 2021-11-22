using CodePattern_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePattern_1.Models
{
    public class Receipt : IReceipt
    {
        public IStandardService StandardService { get; set; }
        public IWash Wash { get; set; }

        public IClawCutting ClawCutting { get; set; }
        public decimal TotalCost { get; set; }

        ISetServicePriceAndName setServicePriceAndName = Factory.SetPriceAndName();
      
        public void ShowReceipt(IStandardService standardService, IClawCutting clawCutting, IWash wash, List<IAnimal> animals, IAnimal animal)
        {
            setServicePriceAndName.SetPrices(standardService, wash, clawCutting);
            setServicePriceAndName.SetName(standardService, wash, clawCutting);
            Console.WriteLine("Skriv in hundens namn igen för kvitto:");
            var name = Console.ReadLine();

            if (animals.Any(animal => animal.AnimalName == name))
            {
                animal.AnimalName = name;
                Console.Write($"Skriv ut kvitto på {animal.AnimalName}? (ja/nej) ");
                var _kvitto = Console.ReadLine();

                if (_kvitto.ToLower() == "ja")
                {
                    var search = animals.FirstOrDefault(x => x.AnimalName == name);
                    if (search.IsCheckedIn == false)
                    {
                        if (search != null)
                        {
                            if (search.Wash.Status == true && search.ClawCutting.Status == true)
                            {
                                var totalCost = standardService.Price + wash.Price + clawCutting.Price;
                                Console.WriteLine($"Tjänster: {standardService.Name}, {clawCutting.Name}, {wash.Name}, Totalkostnad: {totalCost}kr");
                            }
                            else if (search.Wash.Status == true && search.ClawCutting.Status == false)
                            {
                                var totalCost = standardService.Price + wash.Price;
                                Console.WriteLine($"Tjänster: {standardService.Name}, {wash.Name}, Totalkostnad:{totalCost}kr");
                            }
                            else if (search.Wash.Status == false && search.ClawCutting.Status == true)
                            {
                                var totalCost = standardService.Price + clawCutting.Price;
                                Console.WriteLine($"Tjänster: {standardService.Name}, {clawCutting.Name}, Totalkostnad: {totalCost}kr");
                            }
                            else if (search.Wash.Status == false && search.ClawCutting.Status == false)
                            {
                                var totalCost = standardService.Price;
                                Console.WriteLine($"Tjänster: {standardService.Name}, Totalkostnad: {totalCost}kr");
                            }
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
            }
        }
    }
}
