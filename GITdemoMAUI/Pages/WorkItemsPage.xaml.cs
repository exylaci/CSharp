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
    public WorkItemsPage(WorkItemsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}