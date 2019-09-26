using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartExtension.Core.Model
{
    public abstract class  CartItem
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
