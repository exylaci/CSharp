namespace Mobile.Dtos.Results;

public enum ServiceErrorCode //a program logika számára. Ez alapján a frontend pontosan tudni fogja, hogy milyen típusú hiba történt a backendben a műveletek során. A hibaazonosító (enum vagy string kód) előnye főleg akkor jön elő, amikor több kliens, több nyelv vagy több tucat hibatípus jelenik meg. Csak szöveges hibaüzenettel később nehezebben karbantartható a program.
{
    None,       //Fontos, hogy ugyanaz legyen a sorrend, mint a backendben. Ha van rá mód, akkor célszerű egy közös DTO-ban megadni ezeket.
    NotFound,
    AlreadyExists,
    ValidationError,
    Unauthorized,
    DatabaseError,
    UnknownError,
    CommunicationError
}