namespace MauiRetegekPelda.Model;

public record ContactSummaryData(
    string Name,
    string Email,
    string Phone,
    IReadOnlyList<string> Tags
);
//Nem egy teljes osztály, csak egy DataTransferObject. De így típus biztos az alaklmazásunk.
//A Tags lista mem kell hogy módosítható legyen, mert ezt csak az adatok átvitelére használjuk.