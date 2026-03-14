using System.ComponentModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;
using GITdemoMAUI.Pages;

namespace GITdemoMAUI.ViewModels;

public sealed class WorkItemEditorViewModel : BaseViewModel, INavigationParameterReceiver
//INavigationParameterReceiver segítségével kapja meg az adatokat a hívótól
{
    private readonly IWorkItemRepository _repository; //Az adatok tárolásához
    private readonly INavigationService _navigation; //A navigációhoz kell

    private string? id;
    private string title = string.Empty; //A workitem beviteléhez szüksége, az egyes mezőihez tartozó lokális változók
    private string description = string.Empty;
    private WorkItemStatus status = WorkItemStatus.Todo;
    private string titleError = string.Empty; //A címre vonatkozó szabályok megszegésekor kerül bele szöveg
    private bool hasTitleError; //Meg vannak-e szegve a címre vonatkozó szabályok

    private string mode = "Create";


    public RelayCommand ClearFieldsCommand { get; } //A [CLEAR] gomb megnyomására ide ugrik
    public AsyncRelayCommand SaveCommand { get; } //A [SAVE] gomb megnyomására ide ugrik
    public AsyncRelayCommand CancelCommand { get; } //A [MÉGSEM] gomb megnyomására ide ugrik


    public IEnumerable<WorkItemStatus> StatusOptions => Enum.GetValues(typeof(WorkItemStatus)).Cast<WorkItemStatus>(); //A picker-ben választható elemeket állítja elő
    public IReadOnlyList<WorkItemStatus> StatusOptions2 { get; } = Enum.GetValues<WorkItemStatus>(); //A picker-ben választható elemeket állítja elő


    public string Title
    {
        get => title;
        set
        {
            if (SetField(ref title, value))
            {
                Validate();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string Description
    {
        get => description;
        set => SetField(ref description, value);
    }

    public WorkItemStatus Status
    {
        get => status;
        set => SetField(ref status, value);
    }

    public string TitleError
    {
        get => titleError;
        set => SetField(ref titleError, value);
    }

    public bool HasTitleError
    {
        get => hasTitleError;
        set => SetField(ref hasTitleError, value);
    }


    public WorkItemEditorViewModel(INavigationService navigation, IWorkItemRepository repository)
    {
        _repository = repository; //Tárolt workitemek
        _navigation = navigation; //Navigáció
        base.PageTitle = "Új feladat hozzáadása"; //A page fejlécében kiírt név

        ClearFieldsCommand = new RelayCommand(ClearFields); //mezők kiürítése
        SaveCommand = new AsyncRelayCommand(SaveWorkItemAsync, CanSave); //új elem felvétele, vagy a módosítás mentése, ha nem hibás a title 
        CancelCommand = new AsyncRelayCommand(() => _navigation.GoBackAsync()); //vissza az ezt az ablakot "hívó" ablakra
    }

    private bool CanSave()
    {
        return !IsBusy && !HasTitleError && !string.IsNullOrWhiteSpace(Title);
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            HasTitleError = true;
            TitleError = "Kötelező címet adni!";
            return;
        }

        if (Title.Trim().Length < 3)
        {
            HasTitleError = true;
            TitleError = "A cím legalább 3 karakter hosszú kell legyen!";
            return;
        }

        TitleError = string.Empty;
        hasTitleError = false;
    }

    public async Task SaveWorkItemAsync()
    {
        if (!CanSave())
        {
            return;
        }

        try
        {
            IsBusy = true; //Éppen mentés zajlik, addig más már nem kérhet mentést
            SaveCommand.RaiseCanExecuteChanged();
            if (mode == "Edit" && id is not null)
            {
                _repository.Update(new WorkItem(id, Title.Trim(), Description.Trim(), Status));
                ClearFields();
                await _navigation.GoBackAsync();
            }
            else
            {
                _repository.Add( //eltároljuk az új feladatot
                    new WorkItem(
                        Guid.NewGuid().ToString("N"), //generál egy 32 karakteres azonosítót
                        Title.Trim(),
                        Description.Trim(),
                        Status));
                ClearFields();
                await _navigation.GoToAsync(Routes.WorkItems);
            }
        }
        finally
        {
            IsBusy = false; //ha hibára futott, akkor is törölni kell a foglaltság visszajelzését
            SaveCommand.RaiseCanExecuteChanged();
        }
    }

    private void ClearFields()
    {
        Title = string.Empty;
        Description = string.Empty;
        Status = WorkItemStatus.Todo;
    }

    public void Receive(IDictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("Mode", out var modeObj) && modeObj is string mode)
        {
            this.mode = mode;
        }

        if (parameters.TryGetValue("WorkItem", out var obj) && obj is WorkItem item)
        {
            id = item.Id;
            Title = item.Title;
            Description = item.Description;
            Status = item.Status;
            PageTitle = "Módosítás";
        }

        OnPropertyChanged(nameof(CanSave)); //Figyeli, hogy megváltozott-e a CanSave
        SaveCommand.RaiseCanExecuteChanged();
    }
}