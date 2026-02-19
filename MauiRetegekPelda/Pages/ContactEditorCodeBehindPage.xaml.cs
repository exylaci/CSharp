using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;

namespace MauiRetegekPelda.Pages;
//Ez arra példa, aikor minden a csak a megjelenítésért felelős program modulban van. Mint a WIndowsForms-nál. Nagyon erőforrást igénylő megoldás. Nem praktikus.

public partial class ContactEditorCodeBehindPage : ContentPage
{
    public ContactEditorCodeBehindPage()
    {
        InitializeComponent();
        RefreshPreview();
    }

    private void RefreshPreview()
    {
        NameLabelPreview.Text = string.IsNullOrWhiteSpace(NameEntry.Text) ? "(név)" : NameEntry.Text.Trim();
        EmailLabelPreview.Text = string.IsNullOrWhiteSpace(EmailEntry.Text) ? "(e-mail)" : EmailEntry.Text.Trim();
        TelefonLabelPreview.Text = string.IsNullOrWhiteSpace(PhoneEntry.Text) ? "(telefon)" : PhoneEntry.Text.Trim();
        // Az egyes elemekben levő értékek átmásolása az előnézetbe. 
    }

    private void OnResetClicked(object? sender, EventArgs e)
    {
        NameEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        PhoneEntry.Text = string.Empty;
        TagEntry.Text = string.Empty;
        TagsFlex.Children.Clear();
        RefreshPreview();
    }

    private void OnFormChange(object? sender, TextChangedEventArgs e)
    {
        RefreshPreview();
    }

    private void OnAddTagClicked(object? sender, EventArgs e)
    {
        string tag = TagEntry.Text.Trim();
        if (string.IsNullOrWhiteSpace(tag))
        {
            return;
        }

        Border chip = CreateChip(tag);          //Saját buborék gyártása
        TagsFlex.Children.Add(chip);            //Ebben flex dobozban tároljuk a chip-einket    
        TagEntry.Text=string.Empty;             //Hozzáadás után kiürítjuk beviteli mezőt
    }

    private Border CreateChip(string text)      //Saját Chips (felugró buborék) készítése 
    {
        Border border = new Border
        {
            Style = Resources["ChipBorder"] as Style,
            StrokeShape = new RoundRectangle { CornerRadius = 16 }
        };
        border.Content = new Label { Text = text };

        TapGestureRecognizer tap = new TapGestureRecognizer();          //Ez az objektum akkor jön létre, ha megérintik a kijelzőt
        tap.Tapped += (_, _) => TagsFlex.Children.Remove(border);       //feliratjuk ennek a buboréknak a tap event listára a névtelen metódusunkat, ami ha hozzá értek a buborékunkhoz kiveszi a buborékokat tároló listából ezt a buborékot
        // (_,_) Az _ jellel jelezzük, hogy az érkező paramétereket nem használjuk fel sehol sem nem.
        border.GestureRecognizers.Add(tap);      //itt adjuk hozzá a buborék "feladataihoz" a hozáérés esetén teendőt                       
        return border;
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Mentés",
            $"Név: {NameLabelPreview.Text}{Environment.NewLine}Email: {EmailLabelPreview.Text}{Environment.NewLine}Telefon: {TelefonLabelPreview.Text}{Environment.NewLine}Tagek: {TagsFlex.Children.Count}",
            "OK");
        //Kb. mint Forms-ban a MessageBox
        //Aszinkron ezért await kell.
    }
}