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
using Observer.Interfaces;
using System.Collections.Generic;

namespace Observer.Implementations
{
    public class Subject:ISubject
    {
        List<IObserver> _observers;

        int _value;
        public int Value 
        { 
            get
            {
                return _value;
            } 

            set
            {
                _value = value;
                this.NotifyObservers();
            } 
        }

        public Subject()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach(observer => observer.Update(Value));
        }
    }
}
