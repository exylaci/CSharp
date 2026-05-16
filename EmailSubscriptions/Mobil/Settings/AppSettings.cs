namespace Mobil.Settings;

public static class AppSettings
{
    public static string BaseApiUrl =>
        DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5210/api/"
            : "http://localhost:5210/api/";
}
