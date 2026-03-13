using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITdemoMAUI.Pages.Controls;

public partial class ValidationMessageView : ContentView
{
    //A kötéshez kellenek statikus property-k. (Magára az üzenetre, és a lázhatóságára.)
    public static readonly BindableProperty MessageProperty =
        BindableProperty.Create( //Létre kell hozni
            nameof(Message), //Meg kell adni a Getter és a Setter nevét
            typeof(string), //A típusát
            typeof(ValidationMessageView), //Declaring type-ját. Jelen esetben a maga ez a ContentView. 
            string.Empty); //Kezdő, default érték megadása.

    public static readonly BindableProperty IsVisibleMessageProperty =
        BindableProperty.Create(nameof(IsVisibleMessage), typeof(bool), typeof(ValidationMessageView), false);

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public bool IsVisibleMessage
    {
        get => (bool)GetValue(IsVisibleMessageProperty);
        set => SetValue(IsVisibleMessageProperty, value);
    }

    public ValidationMessageView()
    {
        InitializeComponent();
    }
}