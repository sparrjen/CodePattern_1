using CodePattern_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePattern_1
{
    public class Dog : IAnimal
    {
        // Properties
        public ICustomer Owner { get; set; }

        public string AnimalName { get; set; }

        public bool IsCheckedIn { get; set; }

        public IStandardService StandardService { get; set; }

        public IWash Wash { get; set; }

        public IClawCutting ClawCutting { get; set; }


        // Funktioner

        public void CreateNewAnimal(List<IAnimal> animals, List<ICustomer> customers)
        {
            IAnimal animal = Factory.CreateAnimal();
            ICustomer customer = Factory.CreateCustomer();
            IWash wash = Factory.CreateWash();
            IClawCutting clawCutting = Factory.CreateClowCutting();

            animal.AnimalName = "";
            animal.IsCheckedIn = false;
            animal.ClawCutting = clawCutting;
            clawCutting.Status = false;
            animal.Wash = wash;
            wash.Status = false;
            animal.Owner = customer;

            Console.WriteLine("Skriv in namn på hunden:");
            animal.AnimalName = Console.ReadLine();

            while (animal.AnimalName == "")
            {
                Console.WriteLine("Ogiltigt alternativ, var god och skriv in namn på hunden igen:");
                animal.AnimalName = Console.ReadLine();
            }

            Console.WriteLine("Ägarens namn:");
            var inputName = Console.ReadLine();
            while (inputName == "")
            {
                Console.WriteLine("Ogiltigt alternativ, var god och skriv in namn på ägaren igen:");
                inputName = Console.ReadLine();
            }

            customer = customers.FirstOrDefault(x => x.UserName == inputName);

            if (customer != null)
            {
                animal.Owner = customer;
                animal.SaveAnimal(animal, animals);
                Console.WriteLine("Hunden är skapad");
            }
            else
            {
                Console.WriteLine("Den här kunden finns inte registrerad i vårat system.");
            }
        }

        public void SaveAnimal(IAnimal animal, List<IAnimal> animals)
        {
            animals.Add(animal);
        }

        public void GetAnimals(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"Hund: {animal.AnimalName}");
            }
        }
        public void GetAnimalsWithOwner(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"Hund: {animal.AnimalName}, Ägare: {animal.Owner.UserName}");
            }
        }

        public void GetAnimalsCeckedIn(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal.IsCheckedIn == true) {
                    Console.WriteLine($"Hund: {animal.AnimalName}, Ägare: {animal.Owner.UserName}, Inlämnad: {animal.IsCheckedIn}");
                }
                else if (animal.IsCheckedIn != true && false)
                {
                    Console.WriteLine("Det finns inga hundar inlämnade");
                }
            }
        }
        public void CheckInAnimal(List<IAnimal> animals, IAnimal animal)
        {
            Console.Write("Skriv in hundens namn:");
            var name = Console.ReadLine();

            while (name == "")
            {
                Console.Write("Ogiltigt alternativ, var god skriv in hundens namn igen:");
                name = Console.ReadLine();
            }

            if (animals.Any(animal => animal.AnimalName == name))
            {
                animal.AnimalName = name;
                Console.Write($"Lämna in hunden {animal.AnimalName}? (ja/nej) ");
                var _checkIn = Console.ReadLine();

                while ((_checkIn != "ja") && (_checkIn != "nej"))
                {

                    Console.Write("Oglitigt svar, var god och svara igen: (ja/nej)");
                    _checkIn = Console.ReadLine();

                }

                if (_checkIn.ToLower() == "ja")
                {
                    var search = animals.FirstOrDefault(x => x.AnimalName == name);
                    if (search != null)
                    {
                        if (search.IsCheckedIn == true)
                        {
                            Console.Write($"{animal.AnimalName} är redan inlämnad. ");
                        }
                        else
                        {
                            search.IsCheckedIn = true;
                            Console.Write($"{animal.AnimalName} är nu inlämnad. ");
                        }
                    }
                }
                else if (_checkIn.ToLower() == "nej")
                {
                    var search = animals.FirstOrDefault(x => x.AnimalName == name);
                    if (search.IsCheckedIn == true)
                    {
                        Console.Write($"{animal.AnimalName} är redan inlämnad. ");
                    }
                    else
                    {
                        Console.Write("Ok, ingen inlämning har skett.");
                    }
                }
            }
            else
            {
                Console.Write("Vi har ingen hund i systemet som heter detta");
            }
        }

        public void CheckOutAnimal(List<IAnimal> animals, IAnimal animal, IReceipt receipt, IStandardService standardService, IClawCutting clawCutting, IWash wash)
        {
            Console.Write("Skriv in hundens namn:");
            var name = Console.ReadLine();

            while (name == "")
            {
                Console.Write("Ogiltigt alternativ, var god skriv in hundens namn igen:");
                name = Console.ReadLine();
            }

            if (animals.Any(animal => animal.AnimalName == name))
            {
                animal.AnimalName = name;
                Console.Write($"Hämta ut hunden {animal.AnimalName}? (ja/nej) ");
                var _checkIn = Console.ReadLine();


                while ((_checkIn != "ja") && (_checkIn != "nej"))
                {

                    Console.Write("Oglitigt svar, var god och svara igen: (ja/nej)");
                    _checkIn = Console.ReadLine();

                }

                if (_checkIn.ToLower() == "ja")
                {
                    var search = animals.FirstOrDefault(x => x.AnimalName == name);
                    if (search.IsCheckedIn == true)
                    {
                        if (search != null)
                        {
                            search.IsCheckedIn = false;
                        }
                        Console.Write($"{animal.AnimalName} är nu hämtad. ");

                        receipt.ShowReceipt(standardService, clawCutting, wash, animals, animal);

                    }
                    else
                    {
                        Console.Write("Ingen har lämnat in denna hund. ");
                    }
                }
                if (_checkIn.ToLower() == "nej")
                {
                    var search = animals.FirstOrDefault(x => x.AnimalName == name);
                    if (search.IsCheckedIn == false)
                    {
                        Console.Write("Ingen har lämnat in denna hund. ");
                    }
                    else if(search.IsCheckedIn == true)
                    {
                        Console.Write($"{animal.AnimalName} är inte hämtad. ");
                    }
                }
            }
            else
            {
                Console.Write("Denna hund är inte inlämnad");
            }
        }

        public void SetExtraServices(List<IAnimal> animals,IAnimal animal)
        {
            Console.WriteLine("Skriv in hundens namn:");
            var name = Console.ReadLine();

            while (name == "")
            {
                Console.Write("Ogiltigt alternativ, var god skriv in hundens namn igen:");
                name = Console.ReadLine();
            }

            animal = animals.FirstOrDefault(x => x.AnimalName == name);

            if (animal != null)
            {
                if (animal.IsCheckedIn == true)
                {
                    Console.WriteLine($"Lägg till kloklippning på {animal.AnimalName}? (ja/nej) ");
                    var _cut = Console.ReadLine();

                    while ((_cut != "ja") && (_cut != "nej"))
                    {
                        Console.Write("Oglitigt svar, var god och svara igen: (ja/nej)");
                        _cut = Console.ReadLine();
                    }

                    if (_cut.ToLower() == "ja")
                    {
                        var search = animals.FirstOrDefault(x => x.AnimalName == name);
                        if (search.ClawCutting.Status == false)
                        {
                            if (search != null)
                            {
                                search.ClawCutting.Status = true;
                                Console.WriteLine($"Kloklippning har lagts till på {animal.AnimalName}");
                            }
                        }
                    }

                    Console.WriteLine($"Lägg till tvätt på {animal.AnimalName}? (ja/nej) ");
                    var _wash = Console.ReadLine();

                    while ((_wash != "ja") && (_wash != "nej"))
                    {
                        Console.Write("Oglitigt svar, var god och svara igen: (ja/nej)");
                        _wash = Console.ReadLine();
                    }

                    if (_wash.ToLower() == "ja")
                    {
                        var search = animals.FirstOrDefault(x => x.AnimalName == name);
                        if (search.Wash.Status == false)
                        {
                            if (search != null) search.Wash.Status = true;
                            Console.Write($"Tvätt har lagts till på {animal.AnimalName}");
                        }
                    }
                }
                else
                {
                    Console.Write("Vi har ingen hund med detta namn som är incheckad");
                }
            }
            else
            {
                Console.Write("Vi har ingen hund i systemet som heter detta");
            }
        }
    }
}


