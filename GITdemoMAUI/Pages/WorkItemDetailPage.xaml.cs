using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.ViewModels;

namespace GITdemoMAUI.Pages;

public partial class WorkItemDetailPage : ContentPage, IQueryAttributable
{
    public WorkItemDetailPage(WorkItemDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;        //Ettől a ViewModeltől kapja majd az adatokat és ennek is küldi. 
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is INavigationParameterReceiver receiver)
        {
            receiver.Receive(query);        //Meghívja a WokrItemDetailViewModel Receive metódusát, amin keresztűl tárolódik az itt kinyert adat 
        }
    }
}