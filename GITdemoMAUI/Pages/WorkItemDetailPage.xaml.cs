using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Models;

namespace GITdemoMAUI.Pages;

public partial class WorkItemDetailPage : ContentPage, IQueryAttributable
{
    public WorkItemDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("WorkItem", out var obj)&& obj is WorkItem workItem)
        {
            BindingContext = workItem;
        }
    }
}