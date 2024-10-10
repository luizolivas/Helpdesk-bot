namespace HelpdeskBot.Services.contracts
{
    public interface IMLService
    {
        string PredictIntent(string message);
    }
}
