namespace PizzaWebApi.Loggers
{
    public class CustomLogger
    {
        public void WriteLog(string message, string caller)
        {
            Console.WriteLine($"{DateTime.Now} [{caller}] {message}");
        }
    }
}
