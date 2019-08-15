using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartExtension.Core.Model;
using CartExtension.Core.Repositories;

namespace CartExtension.Persistence.Repositories
{
    class Cart : ICart
    {
        private IContainerRepository _cart { get; set; }
        public Cart()
        {
            CartConfiguration i = new CartConfiguration();
            _cart = i.CartSort;
        }
        public void Update(CartItem item)
        {
            _cart.Update(item);
        }

        public void Add(CartItem item)
        {
            _cart.Add(item);
        }

        public void Delete(object itemId)
        {
            _cart.Delete(itemId);
        }

        public ICollection<CartItem> GetCart()
        {
            return _cart.GetCart();
        }

        public void SetCart(ICollection<CartItem> cart)
        {
            _cart.SetCart(cart);
        }

        public void ResetCart()
        {
            _cart.ResetCart();
        }
        public int TotalPrice()
        {
            int total = 0;
            var cart = _cart.GetCart();
            foreach (var i in cart)
            {
                total += i.Price * i.Amount;
            }
            return total;
        }
    }
}
