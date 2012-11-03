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
using Observer.Implementations;

namespace Observer
{
    public class MyObserver
    {
        public MyObserver()
        {
            Subject subj = new Subject();
            subj.RegisterObserver(new Duck());
            subj.RegisterObserver(new Cat());
            subj.Value = 2;
        }
        
        
    }
}
