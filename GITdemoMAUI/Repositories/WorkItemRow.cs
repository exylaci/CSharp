using SQLite;

namespace GITdemoMAUI.Repositories;

[Table("work_items")]           //Osztály deklarátum
public sealed class WorkItemRow
{
    [PrimaryKey] public string Id { get; set; } = string.Empty;         //ELsődleges kulcs    
    [MaxLength(200)] public string Title { get; set; } = string.Empty;  //SQLite-ban nincs maxlength validáció, ezt az sqlite-net-pcl csomag biztosítja
    public string Description { get; init; } = string.Empty;
    public int Status { get; set; }                         //Enum szövege helyett csak az érték integert tároljuk az adatbázisban
    public long UpdatedAtUnixMs { get; set; }               //A unix rendszer milisec értékre konvertálás  tökéletes időpont megadásra
}