using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePizza_JD.Models
{
    public class Restaurant
    {
        [Key]
        public Guid RestaurantId { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }
        [MaxLength(100)]
        public string StreetName { get; set; }
        [MaxLength(5)]
        public int HouseNumber { get; set; }
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public int ZipCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }


        //public ICollection<Order> Orders { get; set; }


        //navigation properties
        //public ICollection<RestaurantOrder> RestaurantOrder { get; set; }

    }
}
