using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRetegekPelda.Services;
using MauiRetegekPelda.ViewModels;

namespace MauiRetegekPelda.Pages;

public partial class ContactEditorNavigationPage : ContentPage
{
    private readonly ICurrentPageAccessor
        _pageAccessor; //kell egy pageaccessor, amiben megjegyzi ezt ez current page-nek.

    public ContactEditorNavigationPage(ContactEditorNavigationViewModel vm, ICurrentPageAccessor pageAccessor)
    {
        //konstruktorban fagadjuk a viewmodelt és az aktuális oldalt ahova kiiratunk
        InitializeComponent();
        BindingContext = vm;
        _pageAccessor = pageAccessor;
    }

    protected override void OnAppearing() //ablak megjelenítéséhez
    {
        base.OnAppearing();
        _pageAccessor.CurrentPage = this;
    }

    protected override void OnDisappearing() //ablak bezárásakor
    {
        base.OnDisappearing();
        if (_pageAccessor.CurrentPage == this)
        {
            _pageAccessor.CurrentPage = null;
        }
    }
}
