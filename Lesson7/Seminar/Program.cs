namespace Seminar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString1 = new ConnectionString
            {
                DataSourse = "RYAZENKA\\SQLEXPRESS",
                InitialCatalog = "CardStorageService",
                UserId = "CardStorageServiceUser",
                Password = "12345",
                MultipleActiveResultSets = true,
                App = "EntityFramework"
            };

            List<ConnectionString> connections = new List<ConnectionString>();
            connections.Add(connectionString1);
           

            CacheProvider cacheProvider = new CacheProvider();
            cacheProvider.CacheConnections(connections);

            connections = cacheProvider.GetConnectionsFromCache();

            foreach (var connection in connections)
                Console.WriteLine(connection);

            Console.ReadKey(true);

        }

    }
}