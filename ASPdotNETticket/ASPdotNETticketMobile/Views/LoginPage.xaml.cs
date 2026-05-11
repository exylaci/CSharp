using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPdotNETticketMobile.ViewModels;

namespace ASPdotNETticketMobile.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)  //A login view modelt dependenciben kapja meg
    {
        InitializeComponent();
        BindingContext = viewModel;     //Át is adjuk a Binding context-nek
    }
}