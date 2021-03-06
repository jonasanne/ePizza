﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Topping
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Naam is verplicht")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //navigation properties
        public ICollection<PizzaToppings> PizzaToppings { get; set; }


    }


}
