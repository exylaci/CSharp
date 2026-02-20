using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRetegekPelda.Services;
using MauiRetegekPelda.ViewModels;

namespace MauiRetegekPelda.Pages;

public partial class ContactEditorModelViewDependencyInversionPage : ContentPage
{
    private readonly ICurrentPageAccessor _pageAccessor;
    //A konstruktorban megkapott ViewModell és a Page-re "mutató" pageAccessor példányokkal dolgozunk, saját new példányosítás helyett (nincs new)

    public ContactEditorModelViewDependencyInversionPage(ContactEditorCleanViewModel vm,
        ICurrentPageAccessor pageAccessor)
    {
        InitializeComponent();
        BindingContext = vm;
        _pageAccessor = pageAccessor;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _pageAccessor.CurrentPage = this;
        //Be keel állítani a pageAccessor CurrentPage-et erre az aktuális oldalra.
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_pageAccessor.CurrentPage == this)
        {
            _pageAccessor.CurrentPage = null;
            //Az oldal elünteésekor, pedig ki kell üríten ezt az oldalt a pageAccessor CurrentPage-éből (Ha ide "mutatott".)
        }
    }
}