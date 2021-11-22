using CodePattern_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1
{
    public class Customer : ICustomer
    {
        public IAnimal AnimalName { get; set; }
        public List<IAnimal> Animals { get; set; }
        public int SSO { get; set; }
        public string UserName { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }

        public void SaveCustomers(ICustomer customer, List<ICustomer> customers)
        {
                customers.Add(customer);
        }

        public void GetCustomers(List<ICustomer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Personnummer: {customer.SSO}, Namn: {customer.UserName}, Email: {customer.Email}, Mobil: {customer.PhoneNo}");
            }
        }

        public void CreateNewCustomer(List<ICustomer> customers)
        {
            ICustomer customer = Factory.CreateCustomer();
            customer.SSO = 0;
            customer.UserName = "";
            customer.Email = "";
            customer.PhoneNo = 0;

            Console.WriteLine("Vad har kunden för personnummer?");

            bool iswrong = true;
            while(iswrong)
            {
                try
                {
                    customer.SSO = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Oglitigt svar, var god skriv in kundens personnummer igen:");
                    iswrong = true;
                    continue;
                }
                iswrong = false;
            }

            Console.WriteLine("Vad heter kunden?");
            customer.UserName = Console.ReadLine();

            while (customer.UserName == "")
            {
                Console.WriteLine("Oglitigt svar, var god skriv in kundens namn igen:");
                customer.UserName = Console.ReadLine();
            }

            Console.WriteLine("Vad har kunden för Email?");
            customer.Email = Console.ReadLine();

            while (customer.Email == "")
            {
                Console.WriteLine("Oglitigt svar, var god skriv in kundens Email igen:");
                customer.Email = Console.ReadLine();
            }

            Console.WriteLine("Vad har kunden för telefonnummer?");

            iswrong = true;
            while (iswrong)
            {
                try
                {
                    customer.PhoneNo = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Oglitigt svar, var god skriv in kundens telefonnummer igen:");
                    iswrong = true;
                    continue;
                }
                iswrong = false;
            }

            customer.SaveCustomers(customer, customers);
        }
    }
}

