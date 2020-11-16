using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseMVVM.Data.Tests.UnitTests
{
    [TestClass]
    public class BusinessContextTests : FunctionalTest 
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewCustomer_ThrowsExceptionWhenFirstNameIsNull()
        {
            using(var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "customer@northwind.net",
                    FirstName = null,
                    LastName = "Anderson"
                };

                bc.AddNewCustomer(customer);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewCustomer_ThrowsExceptionWhenFirstNameIsEmpty()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "customer@northwind.net",
                    FirstName = "",
                    LastName = "Anderson"
                };

                bc.AddNewCustomer(customer);
            }
        }

        [TestMethod]
        public void UpdateCustomer_ChangedValuesAreApplied()
        {
            using(var bc = new BusinessContext())
            {
                //Arrange
                var customer = new Customer
                {
                    Email = "douche@northwind.com",
                    FirstName = "David",
                    LastName = "Anderson"
                };

                bc.AddNewCustomer(customer);

                const string newEmail = "new_customer@northwind.com",
                             newFirstName = "Dave",
                             newLastName = "Scott";

                customer.Email = newEmail;
                customer.FirstName = newFirstName;
                customer.LastName = newLastName;

                //Act
                bc.UpdateCustomer(customer);

                //This will reload the object from the DB into the Entity contained in memory.  This is where we update the working memory.
                bc.DataContext.Entry(customer).Reload();

                //Assert
                Assert.AreEqual(newEmail, customer.Email);
                Assert.AreEqual(newFirstName, customer.FirstName);
                Assert.AreEqual(newLastName, customer.LastName);
            }
        }

        [TestMethod]
        public void GetCustomerList_ReturnsExpectedCustomers()
        {
            using (var bc = new BusinessContext())
            {
                bc.AddNewCustomer(new Customer { Email = "1@1.com", FirstName = "1", LastName = "a" });
                bc.AddNewCustomer(new Customer { Email = "2@2.com", FirstName = "2", LastName = "b" });
                bc.AddNewCustomer(new Customer { Email = "3@3.com", FirstName = "3", LastName = "c" });

                var customers = bc.GetCustomerList();

                Assert.IsTrue(customers.ElementAt(0).Id == 1);
                Assert.IsTrue(customers.ElementAt(1).Id == 2);
                Assert.IsTrue(customers.ElementAt(2).Id == 3);

                //Use CollectionAssert by overriding Eqauls in entities or using IComparer in 
                //CollectionAssert for a more foolproof version.

            }
        }

    }
}
