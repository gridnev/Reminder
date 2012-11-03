using System;
using Reminder.ViewModel;

namespace Reminder.Infrastructure
{
    public class ViewModelLocator
    {
        private IViewModelFactory _factory;
        public IViewModelFactory Factory
        {
            private get { return _factory; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _factory = value;
            }
        }

        public TasksViewModel TasksViewModel
        {
            get { return Factory.Create<TasksViewModel>(); }
        }
    }
}
