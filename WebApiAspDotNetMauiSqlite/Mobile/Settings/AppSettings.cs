namespace Mobile.Settings;

public class AppSettings
{
    public static string BaseApiUrl => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5210/" : "https://localhost:5210/"; //android emulátor virtuális mobiljánál a localhost helyett 10.0.2.2 kell.
}