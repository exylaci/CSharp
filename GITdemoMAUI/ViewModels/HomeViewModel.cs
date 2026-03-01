using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GITdemoMAUI.ViewModels;

public class
    HomeViewModel : INotifyPropertyChanged
//Ennek az eventjával szól, hogy frissülnie kell a kírásnak (Implementáltatni a Riderrel.)
{
    //A homepage oldal kiszolgálásához kell, hogy ne codebehind legyen a logika hanem itt legyen bindingolva

    private readonly IClock _clock; //átkerül ide az óra
    private string _nowText; //A kiiratandó (injektálandó?) idó
    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand RefreshCommand { get; } //gombnyomásra végrehajtandó command

    public string NowText
    {
        get => _nowText;
        private set
        {
            if (_nowText != value) //ha megváltozott az érték
            {
                _nowText = value;
                OnPropertyChanged(); //kiíratjuk
            }
        }
    }

    public HomeViewModel(IClock clock)
    {
        _clock = clock;
        _nowText = "-";
        RefreshCommand = new Command(Refresh);
        Refresh();
    }

    private void Refresh()
    {
        NowText = "Most: " + _clock.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}