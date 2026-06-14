namespace Api.Dtos.Results;

public enum ServiceErrorCode //a program logika számára. Ez alapján a Controller pontosan tudni fogja, hogy milyen típusú hiba történt a business logic műveletek során és annak megfelelő HTTP státuszkódot küldhet vissza a Mobile kliensnek. A külön hibaazonosító (enum vagy string kód) előnye főleg akkor jön elő, amikor több kliens, több nyelv vagy több tucat hibatípus jelenik meg. Külön kód nélkül később nehezebben karbantartható a program.
{
    None,
    NotFound,
    AlreadyExists,
    ValidationError,
    Unauthorized,
    DatabaseError,
    UnknownError //A lista bővítésénél figyelni kell arra, hogy a frontendben azonos sorrendben legyenek a hibakódok. 
}