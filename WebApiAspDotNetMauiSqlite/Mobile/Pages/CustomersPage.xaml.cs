using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.ViewModels;

namespace Mobile.Pages;

public partial class CustomersPage : ContentPage
{
    public CustomersPage(CustomersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}