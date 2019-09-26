using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CartExtension.Core.Model;
using CartExtension.Core.Repositories;


namespace CartExtension.Persestince.Repositories
{
    class SessionContainerRepository: IContainerRepository
    {
        public void Add(CartItem item)
        {
            var cart = (List<CartItem>)GetCart();
            if (cart.Count(x => x.Id == item.Id) != 0)
            {

                cart.First(x => x.Id.Equals(item.Id)).Amount = cart.First(x => x.Id.Equals(item.Id)).Amount + item.Amount;

            }
            else
            {
                cart.Add(item);
            }

            SetCart(cart);
        }

        public void Delete(string itemId)
        {
            
            ICollection<CartItem> cart = GetCart();
            CartItem i = cart.FirstOrDefault(x => x.Id == itemId);
            if (i != null)
            {
                cart.Remove(i);
                SetCart(cart);
            }
        }

        public ICollection<CartItem> GetCart()
        {
            if ((List<CartItem>)HttpContext.Current.Session["Cart"] != null)
                return (List<CartItem>)HttpContext.Current.Session["Cart"];
            return new List<CartItem>();
        }

        public void ResetCart()
        {
            HttpContext.Current.Session["Cart"] = new List<CartItem>();
        }

        public void SetCart(ICollection<CartItem> cart)
        {
            HttpContext.Current.Session["Cart"] = cart;
        }

        public void Update(CartItem item)
        {
            List<CartItem> cart = (List<CartItem>)GetCart();
            CartItem i = cart.FirstOrDefault(x => x.Id == item.Id);
            cart.Remove(i);
            cart.Add(item);
            SetCart(cart);
        }
    }
}
