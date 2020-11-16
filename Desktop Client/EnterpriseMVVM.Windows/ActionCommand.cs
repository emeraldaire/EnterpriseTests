using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EnterpriseMVVM.Windows
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> predicate;


        public ActionCommand(Action<object> action) : this(action,null)
        {
            //Fall through to the next constructor.
        }

        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            if(action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public bool CanExecute(object parameter)
        {
            if(predicate == null)
            {
                return true;
            }

            //The result of the predicate will always be some condition.
            return predicate(parameter); 
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }
    }
}
