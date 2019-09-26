using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CartExtension.Core.Model;
using CartExtension.Core.Repositories;
using Newtonsoft.Json;

namespace CartExtension.Persestince.Repositories
{
    class CookieContainerRepository :IContainerRepository
    {
        public void Add(CartItem item)
        {
            ICollection<CartItem> cart = GetCart();
            cart.Add(item);
            SetCart(cart);
        }

        public void Delete(string itemId)
        {
            ICollection<CartItem> Cart = GetCart();
            CartItem i = Cart.FirstOrDefault(x => x.Id == itemId);
            Cart.Remove(i);
            SetCart(Cart);
        }

        public ICollection<CartItem> GetCart()
        {
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                List<CartItem> i = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["Cart"].Value), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                return i;
            }
            return new List<CartItem>();
        }

        public void ResetCart()
        {
            var cookie = new HttpCookie("Cart")
            {
                Expires = DateTime.Now.AddDays(-2)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SetCart(ICollection<CartItem> cart)
        {
            string value = JsonConvert.SerializeObject(cart, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            var cookie = new HttpCookie("Cart", value)
            {
                Expires = DateTime.Now.AddDays(1)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void Update(CartItem item)
        {
            ICollection<CartItem> Cart = GetCart();
            CartItem i = Cart.FirstOrDefault(x => x.Id == item.Id);
            Cart.Remove(i);
            Cart.Add(item);
            SetCart(Cart);
        }
    }
}
