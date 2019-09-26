using System.Collections.Generic;
using CartExtension.Core.Model;

namespace CartExtension.Core.Repositories
{
    internal interface ICart
    {
        void Update(CartItem item);
        void Add(CartItem item);
        void Delete(string itemId);
        ICollection<CartItem> GetCart();
        void SetCart(ICollection<CartItem> cart);
        void ResetCart();
    }
}