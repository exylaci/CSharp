using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.ViewModels;

namespace GITdemoMAUI.Pages;

public partial class AddNewWorkingItemPage : ContentPage
{
    public AddNewWorkingItemPage(AddNewWorkingItemViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}