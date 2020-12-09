using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Models
{
    public class CartDTO
    {

        public OrderTypes OrderType { get; set; }
        public int TimeToPrepare { get; set; } // minutes
        public DateTime DateOfEntry { get; set; } 
        //nodig??
        //public Guid CustomerId { get; set; }
        public ICollection<CartItemDTO> CartItems { get; set; }

    }
}
