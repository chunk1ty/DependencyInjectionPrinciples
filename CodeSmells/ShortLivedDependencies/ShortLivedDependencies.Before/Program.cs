using System;

namespace ShortLivedDependencies.Before
{
    class Program
    {
        public static void Main()
        {
            using (IConnectionService connection = new ConnectionService())
            {
                connection.GetConnection();
            }
        }
    }

    public class ConnectionService : IConnectionService
    {
        public void GetConnection() => Console.WriteLine("Get connection");
        public void Dispose() => Console.WriteLine("Dispose");
    }
    public interface IConnectionService : IDisposable
    {
        void GetConnection();
    }
}
