using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiRetegekPelda.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged //Riderrel implementálva az INotifyPropertyChanged-et
// Model view használatával szétválik a megjelenítés és a logika. Eventek helyett bindingok használata.
//   Page-ek tartalmazzzák a megjelenítést,
//   A commandok pedig, hogy mit kell csinálni
// Teljesen tesztelhető viewmodel, függetlenül attól, hogy milyen lesz a megjelenítés.
// INotifyPropertyChanged Propertyket figyel, a képernyő csak akkor frissül, ha ennek "segítségével szólunk neki", hogy fissülnie kell.
// Azért base, mert ha több viewmodel készül, akkor az összesnek ez ad egy default property change eseményt és egy set prepertyt.
// A texteket is bindingoljut, a getterekre hivatkozva az eventek alapján frissíteni tudja a UI-t. (Ami megváltozik, az PropertyChanged eseményt küld. Ez alapján a UI frissülnitud.)
// A view (xaml) nem hívhat egyetlen metódust sem közvetlenül, helyette bindingoljuk, command-okat hív.
//   Text-eket property-kkel,
//   ICommandokkal bindingolt kommandokat hív minden esetben.
// A Helpers/ReleyCommand segéd osztály implementálja az ICommand-ot,
// Execute: mit csináljon,
// CanExecute: szabad-e most csinálnia (Kapcsolgatható, hogy végrehajtsa-e, vagy sem.)

{
    public event PropertyChangedEventHandler?
        PropertyChanged; //Ez az event kell a frissülésekhez így "veszi észre" a változásokat.

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    // field: (referenciáján keresztül) a régi érték; value: az új beállítandó érték
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false; //Ha nem változott, nem kell csinálni semmit
        field = value;
        OnPropertyChanged(propertyName);    
        return true;
    }

    protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //Kézi frissítési lehetőség
}