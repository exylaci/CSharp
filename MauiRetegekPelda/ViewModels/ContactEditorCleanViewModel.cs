using System.Collections.ObjectModel;
using MauiRetegekPelda.Helpers;
using MauiRetegekPelda.Services;

namespace MauiRetegekPelda.ViewModels;

public sealed class ContactEditorCleanViewModel : BaseViewModel
{
//A ViewModelből nem szabad Display Allertet hívni, mert allert boxot, csak a UI hívhat.
//Helyette a ViewModel és a UI között hidat képező a szervíz (Szolgáltatás) rétegből kell meghívni

//A képernyő (page-ek) állapotát és a műveleteket tartalmazza    
//jelen esetben az állapotok: name, email, phone, newtag
//               a műveletek: AddTagCommand, RemoveTagCommand, ResetCommand, SaveCommand
    private readonly IDialogService _dialogService;
    //Ebben a dialogus szervízben tároljuk a konstruktorban kapott szervíz réteget, hogy tudjuk kit kell megkérni kiíratás elvégeztetésére  

    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _phone = string.Empty;
    private string _newTag = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            if (SetField(ref _name, value)) //referenciűval a mező nevére (így elérhető a bennelevő "régi" érték)
                //,és az új beállítandó értékkel hívjuk meg
            {
                SaveCommand.RaiseCanExecuteChanged();
                //ha true értékkel tér vissza a név mező tartalma megváltozik, és akkor elérhetővé válik a [Save] gombunk
            }
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (SetField(ref _email, value))
            {
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string Phone
    {
        get => _phone;
        set => SetField(ref _phone, value);
    }

    public string NewTag
    {
        get => _newTag;
        set
        {
            if (SetField(ref _newTag, value))
            {
                AddTagCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public ObservableCollection<string> Tags { get; } = new();
    //new()  <- mint c++-ban, itt sem kell jobboldalon újra beírni a típusát
    //Observable kollekcióban tárolva, a lista tud automatikusan szólni a UI-nak hogy frissíteni kell a képernyőt

    public RelayCommand AddTagCommand { get; } //A set alapból privateként benne van, oda sem kell írni

    //Ezeket a Commandokat fogja végrehajtani az adott gombra kattintáskor.
    public RelayCommand<string> RemoveTagCommand { get; }
    public RelayCommand ResetCommand { get; }
    public RelayCommand SaveCommand { get; }

    public ContactEditorCleanViewModel(IDialogService service)
    {
        _dialogService = service;
        //itt a konstruktorban drótozzuk fel a kommandokhoz a művelet függvényeinket
        AddTagCommand =
            new RelayCommand(AddTag, CanAddTag); //Csak akkor lesz aktív az [Add] gomb, ha a Tag mező nem üres
        RemoveTagCommand = new RelayCommand<string>(RemoveTag);
        ResetCommand = new RelayCommand(Reset);
        SaveCommand = new RelayCommand(Save, CanSave);
    }

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
    //ha ki van töltve a név és az email aktív lehet a [Save] gombunk

    private async void Save()
    {
        await _dialogService.ShowMessageAsync("Mentés",
            $"Név: {Name}{Environment.NewLine}Email: {Email}{Environment.NewLine}Telefon: {Phone}{Environment.NewLine}Tagek: {Tags.Count}",
            "OK");
        //A konstruktorban kapott dialógus szervízt kéri meg, hogy írja ki (jeleníttese meg) az adatokat.
        //ShowMessageAsync: kb. mint a WindowsForm-ban a MessageBox. (cimke,szöveg,gomb)
    }

    private void Reset()
    {
        Name = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        NewTag = string.Empty;
        Tags.Clear(); //kiürítjük az observable collectionunkat
    }

    private void RemoveTag(string? tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            return;
        }

        Tags.Remove(tag); //eltávolítjuk az observable collectionunkból
    }

    private bool CanAddTag() => !string.IsNullOrWhiteSpace(NewTag);
    //Állítjuk a canaddtag true/false értékét, a newtag mező üressége alapján

    private void AddTag()
    {
        string tag = NewTag.Trim();
        if (tag.Length == 0)
        {
            return;
        }

        Tags.Add(tag); //Hozzáadjuk az observable collectionunkhoz
        NewTag = string.Empty;
    }
}