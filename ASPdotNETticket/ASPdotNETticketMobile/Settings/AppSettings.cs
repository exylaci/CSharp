namespace ASPdotNETticketMobile.Settings;

public static class AppSettings
{
    public static string BaseApiUrl => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5210" : "https://localhost:5210"; //Virtuális mobilnálnál android emulátorral a 10.0.2.2 kell a localhost helyett. 
    public const string AuthTokenKey = "auth_token"; //Tároló a tokennek (Nem a jelszavát tároljuk el, hanem a backend-től login-nél kapott tokent
    public const string CurrentUserNameKey = "current_user_name"; //tároló felhasználó nevének
    public const string CurrentUserRoleKey = "current_user_role"; //tároló szerepkörének
}