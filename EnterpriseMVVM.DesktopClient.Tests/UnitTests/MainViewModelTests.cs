using EnterpriseMVVM.Data;
using EnterpriseMVVM.Data.Tests;
using EnterpriseMVVM.DesktopClient.ViewModels;
using EnterpriseMVVM.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseMVVM.DesktopClient.Tests.UnitTests
{
    [TestClass]
    public class MainViewModelTests : FunctionalTest
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(MainViewModel).BaseType == typeof(ViewModel));
        }

        //[TestMethod]
        //public void ValidationErrorWhenCustomerNameExceeds32Characters()
        //{
        //    var viewModel = new CustomerViewModel
        //    {
        //        CustomerName = "123456789abcdefghijklmnopqrstuvabscdedsddeidlskeuisljjnviewelfsdieja"
        //    };

        //    Assert.IsNotNull(viewModel["CustomerName"]);
        //}

        //[TestMethod]
        //public void ValidationErrorWhenCustomerNameIsNotGreaterThanOrEqualTo2Characters()
        //{
        //    var viewModel = new MainViewModel
        //    {
        //        CustomerName = "B"
        //    };

        //    Assert.IsNotNull(viewModel["CustomerName"]);
        //}

        //[TestMethod]
        //public void NoValidationErrorWhenCustomerNameMeetsAllRequirements()
        //{
        //    var viewModel = new MainViewModel
        //    {
        //        CustomerName = "David Anderson"
        //    };

        //    Assert.IsNull(viewModel["CustomerName"]);
        //}

        //[TestMethod]
        //public void ValidationErrorWhenCustomerNameIsNotProvided()
        //{
        //    var viewModel = new MainViewModel
        //    {
        //        CustomerName = null
        //    };

        //    Assert.IsNotNull(viewModel["CustomerName"]);
        //}

        //[TestMethod]
        //public void AddCustomerCommandCannotExecuteWhenFirstNameIsNotValid()
        //{
        //    var viewModel = new MainViewModel
        //    {
        //        FirstName = null,
        //        LastName = "Anderson",
        //        Email = "idiot@northwind.net"
        //    };

        //    Assert.IsFalse(viewModel.AddCustomerCommand.CanExecute(null));
        //}


        //[TestMethod]
        //public void AddCustomerCommandAddsCustomerToCustomerCollectionWhenExecutedSuccessfully()
        //{
        //    var viewModel = new CustomerViewModel
        //    {
        //        FirstName = "David",
        //        LastName = "Anderson",
        //        Email = "directionlessfool@northwind.net"
        //    };

        //    viewModel.AddCustomerCommand.Execute();

        //    Assert.IsTrue(viewModel.Customers.Count == 1);
        //}
        
        [TestMethod]
        public void GetCustomerListCommandPopulatesCustomersProperty()
        {
            using (var context = new BusinessContext())
            {
                context.AddNewCustomer(new Customer { Email = "1@1.com", FirstName = "1", LastName = "a" });
                context.AddNewCustomer(new Customer { Email = "2@2.com", FirstName = "2", LastName = "b" });
                context.AddNewCustomer(new Customer { Email = "3@3.com", FirstName = "3", LastName = "c" });

                var viewModel = new MainViewModel(context);

                viewModel.GetCustomerListCommand.Execute(null);

                Assert.IsTrue(viewModel.Customers.Count == 3);
                
            }
        }



    }
}
