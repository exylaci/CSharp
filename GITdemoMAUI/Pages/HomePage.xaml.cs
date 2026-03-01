using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITdemoMAUI.Pages;

public partial class HomePage : ContentPage
{
    private readonly IClock _clock; //Ebben "tároljuk" a konstruktorban megkapott órát

    public HomePage(IClock clock)
    {
        InitializeComponent();
        _clock = clock;
        UpdateTime();
    }

    private void UpdateTime()
    {
        TimeLabel.Text = "Most: " + _clock.Now.ToString("yyyy.MM.dd HH:mm:ss");
    }

    private void OnRefreshClicked(object? sender, EventArgs e) //Kattra ezt hívja meg az oldalon a gomb.
    {
        UpdateTime();
    }
}