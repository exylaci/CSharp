using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Mobile.Dtos;
using Mobile.Dtos.Results;
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
    public event Action<string>? OnError;
    public event Func<string, string, Task<bool>>? OnConfirm;

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
            OnError?.Invoke("Nem sikerült elérni az adabázist.");
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
        if (!ValidateCustomerModel())
        {
            return; //Nem teljesült valamelyik validációs annotácós feltétel. Pl: nem adott meg e-mail címet. 
        }

        CustomerDto? customerDto = await _customerApiService.GetCustomerByEmailAsync(Email);
        if (customerDto is null)
        {
            OnError?.Invoke($"Nem található a {Email} e-mail cím.");
            return; //Nincs találat a megadott Email címre
        }

        Email = customerDto.Email;
    }

    private async Task CreateCustomerAsync() //http hívás miatt async kell legyen
    {
        if (!ValidateCustomerModel()) //a CustomerModelre akasztott Annotációk ellenőrzése, (saját függvénybe kiszervezve, a boiler plate elkerülésére) 
        {
            return; //Nem teljesült valamelyik validációs annotácós feltétel. Pl: nem adott meg e-mail címet. 
        }

        ServiceResult<CustomerDto> result = await _customerApiService.CreateCustomerAsync(new CustomerDto { Email = Email }); //Frontend Model konvertálása backendnek átadandó Dto-ba. És Backend Api meghívatása a DI-ben kapott CustomerApiService-zel.
        if (!result.Success) //Valamin elhasalt a backend elérése, vagy az ottani műveletek egyike
        {
            OnError?.Invoke(result.ErrorMessage ?? "Ismeretlen hiba történt."); //Hibaüzeneteket kiíró ablak feldobatása a Page-dzsel, a Page event-jének aktiválásával, a hibaüzenet szövege vagy a frontend Servicétől, vagy a backendtől jön.
            return; //Nem sikerült a megadott e-mail címmel létrehozni.
        }

        Customers.Add(new CustomerModel { Email = result.Data!.Email }); //Itt konvertáljuk át a backendtől kapott DTO-t A frontendben használt MODEL-ünkre ahhoz, hogy a Mobilpn helyi Customers kollekciónkba / adatlistánkba is felvegyük. 

        Email = string.Empty; //Sikeres mentés után a CustomerModel attribútumainak kiürítése
        OnPropertyChanged(nameof(Email)); //Értesítés a MAUI Binding rendszernek, hogy a mezők mögötti (Model) attribútumok értéke megváltozott, ezért frisítse/rajzolja újra ennek a page-nek a megjelenítését.
    }

    private async Task ModifyCustomerAsync()
    {
        if (!ValidateCustomerModel()) //a CustomerModelre akasztott Annotációk ellenőrzése, (saját függvénybe kiszervezve, a boiler plate elkerülésére) 
        {
            return; //Nem teljesült valamelyik validációs annotácós feltétel. Pl: nem adott meg e-mail címet. 
        }

        CustomerDto? modifiedCustomer = await _customerApiService.ModifyCustomerAsync(Email, new CustomerDto { Email = "updated_" + Email });
        if (modifiedCustomer is null)
        {
            OnError?.Invoke($"Nem sikerült a változtatásokat elmenteni.");
            return; //Nem sikerült a megadott e-mail címűt módosítani!";
        }

        Email = string.Empty;
        OnPropertyChanged(nameof(Email));
    }

    private async Task DeleteCustomerAsync()
    {
        if (!ValidateCustomerModel()) //a CustomerModelre akasztott Annotációk ellenőrzése, (saját függvénybe kiszervezve, a boiler plate elkerülésére) 
        {
            return; //Nem teljesült valamelyik validációs annotácós feltétel. Pl: nem adott meg e-mail címet. 
        }

        bool confirmed = await (OnConfirm?.Invoke("Törlés megerősítése", $"Biztos, hogy töröljük a {Email} ügyfelet?") ?? Task.FromResult(false));
        if (!confirmed)
        {
            return; //Nem hagyta jóvá a törlést
        }

        bool success = await _customerApiService.DeleteCustomerAsync(Email);
        if (!success)
        {
            OnError?.Invoke($"Nem sikerült törölni.");
            return; //Nem sikerült a megadott e-mail címűt törölni!";
        }

        Email = string.Empty;
        OnPropertyChanged(nameof(Email));
        await RefreshCustomerListAsync();
    }

    private bool ValidateCustomerModel()
    {
        CustomerModel customerModel = new() { Email = Email }; //CustomerModel.Email = this.Email
        ValidationContext validationContext = new(customerModel); //CustomerModel validáléséra használható context (környezet) -et készít
        List<ValidationResult> validationResults = new(); //Lista a validáció során esetlegesen létrejövő hibajelzések számára
        bool isValid = Validator.TryValidateObject(customerModel, validationContext, validationResults, true); //Itt fut le az összes a CustomerModelre akasztott Annotáció ellenőrzése 
        if (!isValid) //Nem teljesült valamelyik validációs annotácós feltétel. Pl: nem adott meg e-mail címet. 
        {
            string errorMessage = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
            OnError?.Invoke(errorMessage); //Hibaüzeneteket kiíró ablak feldobatása a Page-dzsel, a Page event-jének aktiválásával
        }

        return isValid;
    }
}