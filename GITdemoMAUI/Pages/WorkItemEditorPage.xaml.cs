using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;
using GITdemoMAUI.ViewModels;

namespace GITdemoMAUI.Pages;

public partial class WorkItemEditorPage : ContentPage
{
    public WorkItemEditorPage(WorkItemEditorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}