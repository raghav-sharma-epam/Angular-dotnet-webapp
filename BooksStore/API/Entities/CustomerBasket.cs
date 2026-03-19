using System.Collections.Generic;

namespace API.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
            
        }
        public CustomerBasket()
        {
            
        }

        public string Id { get; set; }
        public List<BasketItem> BasketItems { get; set; }   = new List<BasketItem>();
    }
}
