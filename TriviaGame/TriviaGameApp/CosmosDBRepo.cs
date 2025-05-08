using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Azure.Cosmos;
using static System.Net.WebRequestMethods;

    namespace TriviaGameApp
    {


    public class CosmosDBRepo
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;


        public CosmosDBRepo()
        {
            _cosmosClient = new CosmosClient("****REPLACE ME****");
            _container = _cosmosClient.GetContainer("ccad18", "c3repo");
        }

        public async Task SaveUserAsync(User user)
        {
            try
            {
                await _container.CreateItemAsync(user, new PartitionKey(user.id));
            }
            catch (CosmosException ex)
            {
                Console.WriteLine($"Error writing to Cosmos DB: {ex.Message}");
                throw;
            }
        }
        public User Get(User user)
        {
            
                var response = _container.ReadItemAsync<User>(
                    id: user.id, partitionKey: new PartitionKey(user.id)).Result;
            return response.Resource;
        }
    }
}
