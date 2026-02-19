using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRetegekPelda.Services;
using MauiRetegekPelda.ViewModels;

namespace MauiRetegekPelda.Pages;

public partial class ContactEditorModelViewCleanPage : ContentPage
{
    public ContactEditorModelViewCleanPage()
    {
        InitializeComponent();
        MauiDialogService dialog = new MauiDialogService(this);
        BindingContext = new ContactEditorCleanViewModel(dialog);
        
        //Kell egy dilog szervíz példány amit be tudunk injektálni ViewModelbe
    }
}