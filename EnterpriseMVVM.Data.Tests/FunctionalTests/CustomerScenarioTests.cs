using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseMVVM.Data.Tests.FunctionalTests
{
    [TestClass]
    public class CustomerScenarioTests : FunctionalTest
    {
        [TestMethod]
        public void AddNewCustomerIsPersisted()
        {  
            //We're going to say that the BusinessContext is a UOW around our DomainContext.
            using(var bc = new BusinessContext())
            {
                //Customer entity = bc.AddNewCustomer("David", "Anderson");

                var customer = new Customer
                {
                    Email = "customer@northwind.net",
                    FirstName = "David",
                    LastName = "Anderson"
                };

                bc.AddNewCustomer(customer);

                bool exists = bc.DataContext.Customers.Any(customer => customer.Id == customer.Id);

                Assert.IsTrue(exists);
            }
        }
    }
}
 