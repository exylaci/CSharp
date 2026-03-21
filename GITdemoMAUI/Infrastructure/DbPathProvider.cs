namespace GITdemoMAUI.Infrastructure;

public interface IDbPathProvider
{
    string DbPath { get; }
}

public sealed class DbPathProvider : IDbPathProvider
{
    public string DbPath => Path.Combine(FileSystem.AppDataDirectory, "demowork.db3");  //Az adatbázis helye erősen platform füffő lenne, viszont az AddData könyvtár helye viszont biztosan mindig ugyanott van.
}