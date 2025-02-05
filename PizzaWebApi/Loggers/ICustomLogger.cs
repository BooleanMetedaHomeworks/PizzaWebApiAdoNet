namespace PizzaWebApi.Loggers
{
    // CONSEGNA 05/02/2025
    public interface ICustomLogger
    {
        void WriteLog(string message, string caller);
    }
}
