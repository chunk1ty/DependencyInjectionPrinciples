using System;

namespace ShortLivedDependencies.After
{
    class Program
    {
        public static void Main()
        {
            IConnectionFactory facotry = new ConnectionFactory();

            using (IConnectionService connection = facotry.GetConnectionService())
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

    public class ConnectionFactory : IConnectionFactory
    {
        public IConnectionService GetConnectionService() => new ConnectionService();
    }
    public interface IConnectionFactory
    {
        IConnectionService GetConnectionService();
    }

}
