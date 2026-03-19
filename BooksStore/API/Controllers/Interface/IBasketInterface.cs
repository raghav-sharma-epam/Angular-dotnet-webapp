using API.Entities;
using System.Threading.Tasks;

namespace API.Controllers.Interface
{
    public interface IBasketInterface
    {
        Task<CustomerBasket> GetBasketAsync(string BasketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string BasketId);
    }
}
