using API.Controllers.Interface;
using API.Entities;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers.Repository
{
    public class BasketRepo : IBasketInterface
    {
        private readonly IDatabase database;
        public BasketRepo(IConnectionMultiplexer redisdb)
        {
            database = redisdb.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await database.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string BasketId)
        {
         var data = await database.StringGetAsync(BasketId);
         return data.IsNullOrEmpty?   null   : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),
                TimeSpan.FromDays(30));
            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
