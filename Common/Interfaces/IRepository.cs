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
using Common.BaseTypes;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IRepository
    {
        List<Task> GetAllTasks();
        Task GetTaskById(Guid id);
        void AddTask(Task task);
        void EditTask(Task task);
        void DeleteTask(Guid id);
    }
}
