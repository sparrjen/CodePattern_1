using CodePattern_1.Interfaces;
using CodePattern_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1
{
    static class Factory
    {

        public static IMenuManager CreateMenu()
        {
            return new MenuManager();
        }

        // Skapar nya instancer av klasserna
        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }


        public static IAnimal CreateAnimal()
        {
            return new Dog();
        }

        public static IStandardService CreateStandardService()
        {
            return new StandardService();
        }
        public static IWash CreateWash()
        {
            return new Wash();
        }

        public static IClawCutting CreateClowCutting()
        {
            return new ClawCutting();
        }

        public static IReceipt CreateReceipt()
        {
            return new Receipt();
        }

        public static ISetServicePriceAndName SetPriceAndName()
        {
            return new SetServicePriceAndName();
        }

    }
}
