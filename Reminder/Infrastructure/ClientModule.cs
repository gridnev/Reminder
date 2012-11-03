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
using Autofac;
using FakeDAL;
using Common.Interfaces;
using Reminder.ViewModel;
using Services;

namespace Reminder.Infrastructure
{
    public class ClientModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GeoService>().As<IGeoService>();
            builder.RegisterType<FakeRepository>().As<IRepository>();
        }
    }
}
