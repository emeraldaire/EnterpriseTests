using EnterpriseMVVM.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseMVVM.Windows.Tests.UnitTests
{
    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangeEventHandlerRaised()
        {
            var obj  = new StubObservableObject();

            bool raised = false;
            obj.PropertyChanged += (sender, e) =>
            {
                Assert.IsTrue(e.PropertyName == "ChangedProperty");
                raised = true;
            };

            obj.ChangedProperty = "Some Value";

            if (!raised) Assert.Fail("PropertyChanged was never invoked.");           

        }

        class StubObservableObject : ObservableObject
        {
            private string changedProperty;
            public string ChangedProperty
            {
                get
                {
                    return changedProperty;
                }
                set
                {
                    changedProperty = value;
                    //By using the compiler service 'CallerMemberName', we no longer need to specify the property name, which is set to 
                    //a blank string by default. 
                    NotifyPropertyChanged();
                }
            }
        }


    }
}
