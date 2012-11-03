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
using Common.BaseTypes;
using System.Collections.Generic;

namespace FakeDAL
{
    public class FakeRepository:IRepository
    {

        public List<Task> GetAllTasks()
        {
            return new List<Task> {
                new Task { id = Guid.NewGuid(), Title = "Task1", Description="Desk1" } ,
                new Task { id = Guid.NewGuid(), Title = "Task2", Description="Desk2" } ,
                new Task { id = Guid.NewGuid(), Title = "Task3", Description = "Desk3" },
                new Task { id = Guid.NewGuid(), Title = "Task4" } };
        }

        public Task GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public void EditTask(Task task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
