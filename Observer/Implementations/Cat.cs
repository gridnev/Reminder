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

namespace Observer.Implementations
{
    public class Cat:IObserver
    {
        public void Update(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write("cat");
            Console.WriteLine();
        }
    }
}
