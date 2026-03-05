using System.ComponentModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;
using GITdemoMAUI.Pages;

namespace GITdemoMAUI.ViewModels;

public class AddNewWorkItemViewModel : BaseViewModel, INotifyPropertyChanged
{
    private string _newId = string.Empty;
    private string _newTitle = string.Empty;
    private string _newDescription = string.Empty;
    private WorkItemStatus _newStatus = WorkItemStatus.Todo;
    public IEnumerable<WorkItemStatus> StatusOptions => Enum.GetValues(typeof(WorkItemStatus)).Cast<WorkItemStatus>();

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

    private WorkItem? _item;

    public WorkItem? Item
    {
        get => _item;
        private set => SetField(ref _item, value);
    }

    private readonly IWorkItemRepository _repository;
    private readonly INavigationService _navigation;

    public RelayCommand ClearFieldsCommand { get; }
    public AsyncRelayCommand AddNewItemCommand { get; }


    public AddNewWorkItemViewModel(INavigationService navigation, IWorkItemRepository repository)
    {
        _repository = repository;
        _navigation = navigation;
        Title = "Új elem felvétele";

        ClearFieldsCommand = new RelayCommand(ClearFields);
        AddNewItemCommand = new AsyncRelayCommand(AddNewItem);
    }

    public async Task AddNewItem()
    {
        _repository.Add(new WorkItem(
            NewId,
            NewTitle,
            NewDescription,
            NewStatus));

        ClearFields();
        //await Shell.Current.GoToAsync("//WorkItemsPage");
        await _navigation.GoToAsync(Routes.WorkItems);
    }

    private void ClearFields()
    {
        NewId = string.Empty;
        NewTitle = string.Empty;
        NewDescription = string.Empty;
        NewStatus = WorkItemStatus.Todo;
    }
}