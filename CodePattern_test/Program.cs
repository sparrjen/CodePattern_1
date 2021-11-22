using CodePattern_1.Interfaces;
using CodePattern_1.Models;
using System;
using System.Collections.Generic;

namespace CodePattern_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMenuManager manager = Factory.CreateMenu();
            manager.Menu();
        }
    }
}



