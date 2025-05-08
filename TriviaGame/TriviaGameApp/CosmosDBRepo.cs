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
    public class CosmosDBService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService(string connectionString, string databaseName, string containerName)
        {
            _cosmosClient = new CosmosClient(connectionString);
            _container = _cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddUserAsync(User user)
        {
            await _container.CreateItemAsync(user, new PartitionKey(user.Username));
        }

        public async Task<User> GetUserAsync(string username)
        {
            try
            {
                ItemResponse<User> response = await _container.ReadItemAsync<User>(username, new PartitionKey(username));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var query = _container.GetItemQueryIterator<User>();
            var results = new List<User>();

            while (query.HasMoreResults)
            {
                FeedResponse<User> response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _container.UpsertItemAsync(user, new PartitionKey(user.Username));
        }

        public async Task DeleteUserAsync(string username)
        {
            await _container.DeleteItemAsync<User>(username, new PartitionKey(username));
        }
    }
}
