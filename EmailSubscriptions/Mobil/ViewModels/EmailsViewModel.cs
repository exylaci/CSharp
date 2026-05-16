using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Mobil.Services.Inerfaces;
using Mobil.Dtos;

namespace Mobil.ViewModels;

public class EmailsViewModel : BaseViewModel
{
    private readonly IRegistrationApiService _service;
    private string _email = string.Empty;

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public ObservableCollection<EmailAddressDto> Emails { get; } = [];
    public ICommand SaveEmailCommand { get; }
    public ICommand RefreshCommand { get; }


    public EmailsViewModel(IRegistrationApiService service)
    {
        _service = service;
        SaveEmailCommand = new Command(async () => await SaveEmailAsync());
        RefreshCommand = new Command(async () => await LoadEmailsAsync());
        Task.Run(LoadEmailsAsync);
    }


    private async Task SaveEmailAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            if (string.IsNullOrWhiteSpace(Email))
            {
                await Shell.Current.DisplayAlert("Hiba", "Nincs megadva emailcím, adj meg egyet!", "OK");
                return;
            }

            bool isValid = Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!isValid)
            {
                await Shell.Current.DisplayAlert("Hiba", "Hibás email cím.", "OK");
                return;
            }

            (bool success, string message) = await _service.CreateEmailAsync(Email);
            await Shell.Current.DisplayAlert(success ? "Siker" : "Hiba", message, "OK");
            if (success)
            {
                Email = string.Empty;
                await LoadEmailsAsync();
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task LoadEmailsAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            List<EmailAddressDto> items = await _service.GetAllAsync();
            Emails.Clear();
            foreach (EmailAddressDto item in items)
            {
                Emails.Add(item);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}