using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.BaseTypes;
using System.Collections.ObjectModel;

namespace Common.Interfaces
{
    public interface IGeoService
    {
        void GetAllCategoriesAsync(Action<ObservableCollection<Category>> reply);

        void GetVenuesNearMeAsync(Action<ObservableCollection<Venue>> reply, List<Category> categories);
    }
}
