using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Wishlist
{
    public interface IWishlistRepository
    {
        List<Wishlist> GetAllWishlists();
        Wishlist GetWishlist(int id);
        bool AddWishlist(Wishlist wishlist);
        bool UpdateWishlist(Wishlist wishlist);
        bool DeleteWishlist(int id);
    }
}
