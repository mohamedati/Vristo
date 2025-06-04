using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Application.Common.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _database;

        public CacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task DeleteAsync(string pattern)
        {
            var endpoints = _database.Multiplexer.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = _database.Multiplexer.GetServer(endpoint);

                // الحصول على كل المفاتيح التي تطابق pattern
                var keys = server.Keys(database: _database.Database, pattern: pattern).ToArray();

                if (keys.Length > 0)
                {
                    await _database.KeyDeleteAsync(keys);
                }
            }
        }

        public async  Task<string> GetByKey(string key)
        {
            var value= await _database.StringGetAsync(key);
            return value.HasValue ?value  :""; 
                }

        public async Task SetByKey(string key, string value, TimeSpan? expiry)
        {
            var serialized = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, serialized, expiry);
        }
    }
}
