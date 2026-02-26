using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRetegekPelda.Services;
using MauiRetegekPelda.ViewModels;

namespace MauiRetegekPelda.Pages;

public partial class ContactSummaryPage : ContentPage
{
    private readonly ICurrentPageAccessor _pageAccessor;

    public ContactSummaryPage(ContactSummaryViewModel vm, ICurrentPageAccessor pageAccessor)
    {
        InitializeComponent();
        BindingContext = vm;
        _pageAccessor = pageAccessor;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _pageAccessor.CurrentPage = this;
        //Beállítjuk, hogy amikor éppen megjelenik ez legyen az aktuális Page. 
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_pageAccessor.CurrentPage == this)
        {
            _pageAccessor.CurrentPage = null;
            //Ha még mindig ez az Page az aktuális, akkor ezt a beállítást törölni kell. 
        }
    }
}