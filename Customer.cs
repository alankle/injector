using System;

namespace Injector
{
    internal class Customer : ICustomer
    {
        void ICustomer.CreateCustomer()
        {
           Console.WriteLine("Creating a customer with concrete class injected using constructor injection");
        }
    }
}