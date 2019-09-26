using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartExtension.Core.Model;

namespace CartExtension.Core.Repositories
{
    public interface IContainerRepository
    {
        void Add(CartItem item);
        void Delete(string itemId);
        ICollection<CartItem> GetCart();
        void ResetCart();
        void SetCart(ICollection<CartItem> cart);
        void Update(CartItem item);
    }
}
