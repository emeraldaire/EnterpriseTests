using EnterpriseMVVM.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnterpriseMVVM.Windows.Tests.UnitTests
{
    [TestClass]
    public class ViewModelTests
    {
        //Verify the following conditions:

        //1. Make sure it's an abstract class
        [TestMethod]
        public void IsAbstractBaseClass()
        {
            Type t = typeof(ViewModel);

            Assert.IsTrue(t.IsAbstract);
        }

        //2. That it implements the 'IDataErrorInfo' interface.
        [TestMethod]
        public void IsIDataErrorInfo()
        {
            //The following is a useful way to check if a given type implements a desired interface.
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        //3.  Ensure that the ViewModel is an Observable Object
        [TestMethod]
        public void IsObservableObject()
        {
            //The following is a useful way to check if a given type implements a desired interface.
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }


        //4.  That the built-in Error method is not being called (we won't be using it in this design)
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var viewModel = new StubViewModel();
            var value = viewModel.Error;
        }

        //If we have a property that's decorated with an attribute, we expect a validation error when the data fails to meet the criteria. 
        //Otherwise, when it's valid, the error should be either null or empty.
        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new StubViewModel();
            Assert.IsNotNull(viewModel["RequiredProperty"]);
        }

        //Verify what happens when we DO have a valid property.
        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var viewModel = new StubViewModel
            {
                RequiredProperty = "Some Value"
            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerReturnsErrorMessageForRequestedInvalidProperty()
        {
            var viewModel = new StubViewModel
            {
                RequiredProperty = null,
                SomeOtherProperty = null
            };

            var msg = viewModel["SomeOtherProperty"];

            Assert.AreEqual("The SomeOtherProperty field is required.", msg);

        }


        class StubViewModel : ViewModel
        {
            [Required]
            public string RequiredProperty
            {
                get; set;
            }

            [Required]
            public string SomeOtherProperty { get; set; }

        }




    }
}
