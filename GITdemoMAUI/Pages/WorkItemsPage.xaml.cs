using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Models;
using GITdemoMAUI.ViewModels;

namespace GITdemoMAUI.Pages;

public partial class WorkItemsPage : ContentPage
{
    private readonly WorkItemsViewModel _viewModel;

    public WorkItemsPage(WorkItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private async void OnWorkItemTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not BindableObject bindableObject || bindableObject.BindingContext is not WorkItem workItem)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(WorkItemDetailPage),
            new Dictionary<string, object>
            {
                { "WorkItem", workItem }
            });
    }
}