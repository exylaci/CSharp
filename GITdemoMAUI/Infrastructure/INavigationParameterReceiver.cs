namespace GITdemoMAUI.Infrastructure;

public interface INavigationParameterReceiver
{
    void Receive(IDictionary<string, object> parameters);
}