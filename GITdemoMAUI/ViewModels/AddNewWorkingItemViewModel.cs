using System.ComponentModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public class AddNewWorkingItemViewModel : BaseViewModel, INotifyPropertyChanged
{
    private string _newId = string.Empty;

    public string NewId
    {
        get => _newId;
        set
        {
            if (_newId != value)
            {
                _newId = value;
                OnPropertyChanged(nameof(NewId));
            }
        }
    }

    private string _newTitle = string.Empty;

    public string NewTitle
    {
        get => _newTitle;
        set
        {
            if (value != _newTitle)
            {
                _newTitle = value;
                OnPropertyChanged(nameof(NewTitle));
            }
        }
    }

    private string _newDescription = string.Empty;

    public string NewDescription
    {
        get => _newDescription;
        set
        {
            if (value != _newDescription)
            {
                _newDescription = value;
                OnPropertyChanged(nameof(NewDescription));
            }
        }
    }

    private WorkItemStatus _newStatus = WorkItemStatus.Todo;

    public WorkItemStatus NewStatus
    {
        get => _newStatus;
        set
        {
            if (value != _newStatus)
            {
                _newStatus = value;
                OnPropertyChanged(nameof(NewStatus));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private readonly INavigationService _navigation;
    private WorkItem? _item;
    private readonly IWorkItemRepository _repository;

    public RelayCommand ClearFieldsCommand { get; }
    public AsyncRelayCommand AddNewItemCommand { get; }

    public WorkItem? Item
    {
        get => _item;
        private set => SetField(ref _item, value);
    }

    public AddNewWorkingItemViewModel(IWorkItemRepository repository)
    {
        _repository = repository;
        Title = "Új elem felvétele";

        ClearFieldsCommand = new RelayCommand(ClearFields);
        AddNewItemCommand = new AsyncRelayCommand(AddNewItem);
    }

    public async Task AddNewItem()
    {
        //if (!Enum.TryParse<WorkItemStatus>(NewStatus, out var status)){status = WorkItemStatus.Todo;}

        var item = new WorkItem(
            NewId,
            NewTitle,
            NewDescription,
            NewStatus);
        _repository.Add(item);

        ClearFields();
        await Shell.Current.GoToAsync("//WorkItemsPage");
    }

    public IEnumerable<WorkItemStatus> StatusOptions => Enum.GetValues(typeof(WorkItemStatus)).Cast<WorkItemStatus>();

    private void ClearFields()
    {
        NewId = string.Empty;
        NewTitle = string.Empty;
        NewDescription = string.Empty;
        NewStatus = WorkItemStatus.Todo;
    }
}