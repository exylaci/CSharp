using System.Collections.ObjectModel;
using MauiRetegekPelda.Helpers;
using MauiRetegekPelda.Model;
using MauiRetegekPelda.Services;

namespace MauiRetegekPelda.ViewModels;

public class ContactSummaryViewModel : BaseViewModel, INavigationParameterReceiver
{
    //Ez is a BaseViewModelből származik, és az adatok OOP megkapásához implementálni
    //kell az adatok fogadását leíró interfész is. 
    private readonly INavigationService _navigation;
    //A konstruktorban megkapott navigáció tárolására kell, hogy vissza tudjunk térni a hívóhoz.

    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _phone = string.Empty;

    public string Name
    {
        get => _name;
        private set => SetField(ref _name, value);
    }
    public string Email
    {
        get => _email;
        private set => SetField(ref _email, value);
    }
    public string Phone
    {
        get => _phone;
        private set => SetField(ref _phone, value);
    }
    public ObservableCollection<string> Tags { get; } = new();

    
    public RelayCommand BackCommand { get; }

    public ContactSummaryViewModel(INavigationService navigation)
    {
        _navigation = navigation;
        BackCommand = new RelayCommand(() => _navigation.GoBackAsync());
        //Csak a visszatéréshez szükséges BackCommand-unkat készítjük el.
    }

    public void ApplyNavigationParameter(object? parameter)
    {
        if (parameter is null || parameter is not ContactSummaryData data)
        {   //Ellenőrzni érdemes, hogy kapott-e DTO-t és a típusa megfelelő-e. 
            return;
        }

        Name = data.Name;
        Email = data.Email;
        Phone = data.Phone;
        Tags.Clear();
        foreach (string tag in data.Tags) { Tags.Add(tag); }
    }
}