using System.Collections.ObjectModel;
using System.Windows.Input;
using Mobile.Dtos;
using Mobile.Models;
using Mobile.Services.Interfaces;

namespace Mobile.ViewModels;

public class CustomersViewModel : BaseViewModel
{
    private readonly ICustomerApiService _customerApiService;
    private string _email = string.Empty;
    public ObservableCollection<CustomerModel> Customers { get; set; } = new(); //implementálja az INotifyCollectionChanged, hogy a MAUI UI értesüljön ha megváltozik a lista tartalma
    public ICommand RefreshCustomerListCommand { get; set; }
    public ICommand FindCustomerCommand { get; set; }
    public ICommand CreateCustomerCommand { get; set; }
    public ICommand ModifyCustomerCommand { get; set; }
    public ICommand DeleteCustomerCommand { get; set; }

    public string Email //Riderrel legeneráltatható: kijelölt attribútumokon / Generate Code... / Properties / X Attributumokat / Notify on Property changes: Use method 'SetField(ref, T, T, string?)'
    {
        get => _email;
        set => SetField(ref _email, value);
    }

    public CustomersViewModel(ICustomerApiService customerApiService)
    {
        _customerApiService = customerApiService;
        RefreshCustomerListCommand = new Command(async () => await RefreshCustomerListAsync());
        FindCustomerCommand = new Command(async () => await FindCustomerByEmailAsync());
        CreateCustomerCommand = new Command(async () => await CreateCustomerAsync());
        ModifyCustomerCommand = new Command(async () => await ModifyCustomerAsync());
        DeleteCustomerCommand = new Command(async () => await DeleteCustomerAsync());
    }

    private async Task RefreshCustomerListAsync() //Nem kell visszatérési érték, mert mert a UI észreveszi a változást a bservableCollection<CustomerModel> Customers -ben. és frissíti 
    {
        List<CustomerDto>? dtoCustomers = await _customerApiService.GetAllCustomerAsync();
        if (dtoCustomers is null)
        {
            return;
        }

        Customers.Clear();
        foreach (CustomerDto customerDto in dtoCustomers)
        {
            Customers.Add(new CustomerModel { Email = customerDto.Email }); //Itt konvertáljuk át a backendtől kapott DTO-t A frontendben használt MODEL-ünkre
        }
    }

    private async Task FindCustomerByEmailAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            return; //Nem adott meg e-mail címet.
        }

        CustomerDto? customerDto = await _customerApiService.GetCustomerByEmailAsync(Email);
        if (customerDto is null)
        {
            return; //Nincs találat a megadott Email címre
        }

        Email = customerDto.Email;
    }

    private async Task CreateCustomerAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            return; //Nem adott meg e-mail címet.
        }

        bool success = await _customerApiService.CreateCustomerAsync(new CustomerDto { Email = Email });
        if (!success)
        {
            return; //Nem sikerült a megadott e-mail címmel létrehozni.
        }

        Email = string.Empty;
        OnPropertyChanged(nameof(Email));
    }

    private async Task ModifyCustomerAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            return; //Nem adott meg e-mail címet.
        }

        CustomerDto? modifiedCustomer = await _customerApiService.ModifyCustomerAsync(Email, new CustomerDto { Email = Email });
        if (modifiedCustomer is null)
        {
            return; //Nem sikerült a megadott e-mail címűt módosítani!";
        }

        Email = string.Empty;
        OnPropertyChanged(nameof(Email));
    }

    private async Task DeleteCustomerAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            return; //Nem adott meg e-mail címet.
        }

        bool success = await _customerApiService.DeleteCustomerAsync(Email);
        if (!success)
        {
            return; //Nem sikerült a megadott e-mail címűt módosítani!";
        }

        Email = string.Empty;
        OnPropertyChanged(nameof(Email));
        await RefreshCustomerListAsync();
    }
}