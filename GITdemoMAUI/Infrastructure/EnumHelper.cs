namespace GITdemoMAUI.Infrastructure;

public static class EnumHelper
{
    public static IReadOnlyCollection<T> GetValues<T>() where T : struct, Enum
    {
        // return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        return Enum.GetValues<T>().ToList();
    }
}