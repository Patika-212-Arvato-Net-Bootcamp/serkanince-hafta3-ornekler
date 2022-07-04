using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Data.Redis
{
    public interface IRedisHelper
    {
        Task<bool> SetKeyAsync(string Key, string Value);
        Task<string> GetKeyAsync(string Key);
    }

    public class RedisHelper : IRedisHelper
    {
        public async Task<string> GetKeyAsync(string Key)
        {
            var database = await GetRedisDatabase();


            var value = await database.StringGetAsync(Key);


            return await Task.FromResult((string)value);
        }

        public async Task<bool> SetKeyAsync(string Key, string Value)
        {
            var database = await GetRedisDatabase();

            return await database.StringSetAsync(Key, Value);
        }

        private async Task<IDatabase> GetRedisDatabase()
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { "localhost" },
                Ssl = false,
                AbortOnConnectFail = false,
            };

            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(config);

            return redis.GetDatabase(0);
        }
    }
}
