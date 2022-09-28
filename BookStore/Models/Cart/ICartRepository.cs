using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Cart
{
    public interface ICartRepository
    {
        List<Cart> GetAllCarts();
        Cart GetCart(int id);
        bool AddCart(Cart cart);
        bool UpdateCart(Cart cart);
        bool DeleteCart(int id);
    }
}
