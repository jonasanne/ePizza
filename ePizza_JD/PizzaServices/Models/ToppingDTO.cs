using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ePizza_JD.Models
{
    public class ToppingDTO
    {
        //[Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
