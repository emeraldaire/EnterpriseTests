using EnterpriseMVVM.Data;
using EnterpriseMVVM.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;

namespace EnterpriseMVVM.DesktopClient.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly BusinessContext _context;
        private Customer _selectedCustomer;  

        //Convenience constructor
        public MainViewModel() : this(new BusinessContext())
        {
        }

        public MainViewModel(BusinessContext context)
        {
            _context = context;
            Customers = new ObservableCollection<Customer>();
            GetCustomerList();
        }


        public ICollection<Customer> Customers { get; private set; }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                NotifyPropertyChanged();
            }
        }
     
        public bool IsValid
        {
            get
            {
                //The form is valid if we don't have a selected customer (which is bound to the listbox)
                return SelectedCustomer == null ||  
                        (!String.IsNullOrEmpty(SelectedCustomer.FirstName) &&
                        !String.IsNullOrEmpty(SelectedCustomer.LastName) &&
                        !String.IsNullOrEmpty(SelectedCustomer.Email));
            }
        }

        #region "Commands"
   
        public ActionCommand AddCustomerCommand
        {
            get
            {
                //We define the delegate passed to the command here in the ViewModel. 
                return new ActionCommand(p => AddCustomer(),
                    p => IsValid);
            }
        }

        public ActionCommand SaveCustomerCommand
        {
            get
            {
                return new ActionCommand(p => SaveCustomer(),
                                         p => IsValid);
            }
        }

        public ICommand DeleteCustomerCommand
        {
            get
            {
                return new ActionCommand(p => DeleteCustomer());
            }
        }

        public ICommand GetCustomerListCommand
        {
            get
            {
                return new ActionCommand(p => GetCustomerList());
            }
        }

        #endregion

        #region "BusinessLogicDelegates"
        private void AddCustomer()
        {
            //Here is where we actually define our UOW, represented by the BusinessContext class. 
            //We have validated on the 'API' level through the context and annotations, and we 
            //have validated on the 'UI level' here in the ViewModel. 
            using(var api = new BusinessContext())
            {
                var customer = new Customer
                {
                    FirstName = "New",
                    LastName = "Customer",
                    Email = "new@customer.com" 
                };

                try
                {
                    api.AddNewCustomer(customer);
                }
                catch(Exception e)
                {
                    //TODO: Include error handling.  At this point, any errors are likely coming from SQL or Entity and should be primarily 
                    //errors of concurrency. 
                    return;
                }

                Customers.Add(customer);


            }

        }

        /// <summary>
        /// Updates the selected customer record.
        /// </summary>
        private void SaveCustomer()
        {
            _context.UpdateCustomer(SelectedCustomer);
        }

        /// <summary>
        /// Retrieves the customer list from the database.
        /// </summary>
        private void GetCustomerList()
        {
            //Clear the existing contents of 'Customers'
            Customers.Clear();

            //Retrieve records from DbContext
            foreach(var customer in _context.GetCustomerList())
            {
                Customers.Add(customer);
            }

        }

        /// <summary>
        /// Deletes the selected customer from the database.
        /// </summary>
        private void DeleteCustomer()
        {
            _context.DeleteCustomer(SelectedCustomer);
            //remove from collection
            Customers.Remove(SelectedCustomer);
        }


        #endregion

        //protected override string OnValidate(string propertyName)
        //{
        //    //Include customized validation logic here.
        //    //EXAMPLE BELOW.  Note that much of the validation we need can be provided through data annotations.
        //    if (CustomerName != null && !CustomerName.Contains(" "))
        //    {
        //        return "Customer name must include a First and a Last name, separated by a space.";
        //    }

        //    return base.OnValidate(propertyName);
        //}
    }
}
