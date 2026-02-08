using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PatternsPeldaMAUI.Services;

namespace PatternsPeldaMAUI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly GreetingService _greetingService;
    private readonly IAppSettings _settings;

    private string _output;
    private string _language;
    
    public ICommand RefreshCommand { get; private set; }
    public ICommand ToggleCommand { get; private set; }

    public string Language
    {
        get => _language;
        private set
        {
            if (value == _language)
            {
                return;
            }
            _language = value;
            OnPropertyChanged();
        }
    }

    public string Output
    {
        get => _output;
        private set
        {
            if (value == _output)
            {
                return;
            }
            _output = value; 
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public MainViewModel(GreetingService greetingService, IAppSettings settings)
    {
        _greetingService = greetingService;
        _settings = settings;
        
        _language = _settings.Language;
        _output = "Ready.";

        RefreshCommand = new Command(async () => await RefreshAsync());
        ToggleCommand = new Command(ToggleLanguage);
    }

    private void ToggleLanguage(object obj)
    {
        if (_settings.Language == "hu")
        {
            _settings.Language = "en";
        }
        else
        {
            _settings.Language = "hu";
        }
        Output = _greetingService.Greet("Johnny");
        Language = _settings.Language;
    }

    private async Task RefreshAsync()
    {
        await Task.Delay(1000);
        Output = _greetingService.Greet("Johnny");
        Language = _settings.Language;
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)                                    //Hogy van-e egyáltalán feliratkozója.
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}