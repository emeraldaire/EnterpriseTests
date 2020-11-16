using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EnterpriseMVVM.Data
{ 
    public sealed class BusinessContext : IDisposable
    {
        private bool disposed;
        private readonly DataContext context;

        public DataContext DataContext
        {
            get { return context; }
        }

        //TODO: Implement dependency injection.
        public BusinessContext()
        {
            this.context = new DataContext();
        }

        public Customer AddNewCustomer(Customer customer)
        {
            //Validation code has been replaced with calls to the static 'Check' class.
            Check.Require(customer.Email);
            Check.Require(customer.FirstName);
            Check.Require(customer.LastName);

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer; 

            //At this point, the returned Customer object will remain attached to the InnerContext.  Later, we will decide if we wish to leave it this way. VIDEO #2, 41:00

        }

        public void UpdateCustomer(Customer customer)
        {
            var entity = context.Customers.Find(customer.Id);

            if(entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design.");
            }

            //apply the properties of the object being passed in to the object that was found in the database.  This is equivalent to 'registerDirty' (I think).
            context.Entry(customer).CurrentValues.SetValues(customer);
            context.SaveChanges();
        }

        public ICollection<Customer> GetCustomerList() 
        {
            return context.Customers.OrderBy(p => p.Id).ToArray();
        }

        public void DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }


        /// <summary>
        /// The use of this class is to simplify the validation code within the work classes above. 
        /// </summary>
        static class Check
        {
            public static void Require(string value)
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if(value.Trim().Length == 0)
                {
                    throw new ArgumentException();
                }
            }
        }



        #region "IDisposable Members"
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposed || !disposing)
            {
                return;
            }
            if(context != null)
            {
                context.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
