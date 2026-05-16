using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobil.ViewModels;

namespace Mobil.Pages;

public partial class EmailsPage : ContentPage
{
    public EmailsPage(EmailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}