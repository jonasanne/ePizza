using PizzaServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePizza_JD.Models
{
    public class PizzaDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string[] Toppings { get; set; }
        public IEnumerable<ReviewDTO> Reviews { get; set; }
    }
}
