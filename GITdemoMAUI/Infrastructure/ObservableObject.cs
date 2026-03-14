using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GITdemoMAUI.Infrastructure;

public abstract class ObservableObject : INotifyPropertyChanged // Az INotifyPropertyChanged szól, ha egy property megváltozik
{
    public event PropertyChangedEventHandler? PropertyChanged;  //ez az event hívódik meg a változáskor

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    // [CallerMemberName] -a megváltozott property (vagy attribútum) neve (null, ha nem jött paraméter)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //? ha volt feliratkozó, különben null és nem csinál semmit
        //meghívja az eventre feliratkozott metódusokat
        // a this objektumot és a megváltozott paraméter nevét átadva
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}