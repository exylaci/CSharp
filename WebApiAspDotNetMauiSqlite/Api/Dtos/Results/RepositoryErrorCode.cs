namespace Api.Dtos.Results;

public enum RepositoryErrorCode //az adatbáziskezelés logika számára. Ez alapján a Szervíz rétek pontosan tudni fogja, hogy milyen típusú hiba történt az adatbázis művelet során és annak megfelelő Service hibaüzenetet küldhet vissza a kontroller rétegnek. A külön hibaazonosító (enum vagy string kód) előnye főleg akkor jön elő, amikor több kliens, több nyelv vagy több tucat hibatípus jelenik meg. Külön kód nélkül később nehezebben karbantartható a program.
{
    None,
    NotFound,
    DuplicateKey,
    Unauthorized,
    DatabaseError,
    Timeout,
    UnknownError
}