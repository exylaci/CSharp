using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPdotNETticketMobile.ViewModels;

namespace ASPdotNETticketMobile.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel viewModel;

    public HomePage(HomeViewModel viewModel) //Az ehhez tartozo HomeViewModelt megkapja dependency-ben
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }

    protected override async void OnAppearing() //Felüldefiniáljuk, kiegészítjük azzal, hogy betöltődéskor fusson le a mi inicializálásunk is
    {
        base.OnAppearing();
        await viewModel.InitializeAsync();
    }
}