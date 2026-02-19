using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRetegekPelda.ViewModels;

namespace MauiRetegekPelda.Pages;

public partial class ContactEditorModelViewPage : ContentPage
{
    public ContactEditorModelViewPage()
    {
        InitializeComponent();
        BindingContext = new ContactEditorViewModel();
        //Hozzákötjük a View Modelt (using is kell!)
        //Minden bennevan a VievModel-ben és a bindingon keresztül tesszük elérhetővé az xaml-nek.
    }
}