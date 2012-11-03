using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Common.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;
using Common.BaseTypes;
using System.Collections.ObjectModel;

namespace Reminder.ViewModel
{
    public class TasksViewModel:INotifyPropertyChanged
    {
        private IRepository repository;
        private IGeoService service;

        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set 
            { 
                _tasks = value;
                NotifyPropertyChanged("Tasks");
            }
        }

        private ObservableCollection<Venue> _venues;
        public ObservableCollection<Venue> Venues
        {
            get { return _venues; }
            set 
            {
                _venues = value;
                NotifyPropertyChanged("Venues");
            }
        }
         
        public TasksViewModel(IRepository repository, IGeoService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public void LoadData()
        {
            LoadTasks();
            LoadVenues();
        }

        public void LoadTasks()
        {
            this.Tasks = new ObservableCollection<Task>(this.repository.GetAllTasks());
        }

        public void LoadVenues()
        {
            this.service.GetVenuesNearMeAsync(results => Venues = results, new List<Category>() {new Category(){id="4bf58dd8d48988d1ca941735"}});
        }

        #region INPC Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
