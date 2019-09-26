using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartExtension.Core.Enums;
using CartExtension.Core.Repositories;
using CartExtension.Persestince.Repositories;
using CartExtension.Persistence.Repositories;

namespace CartExtension
{
    public class CartConfiguration
    {
        private static IContainerRepository _cartType;
        public IContainerRepository CartSort
        {
            get { return _cartType; }
        }

        public static void Configure(CartType type)
        {
            switch (type)
            {
                case CartType.Session:
                    _cartType = new SessionContainerRepository();
                    break;
                case CartType.Cookie:
                    _cartType = new CookieContainerRepository();
                    break;
                default:
                    _cartType = new SessionContainerRepository();
                    break;
            }

        }
    }
}
