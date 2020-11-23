using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizza_JD.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0, 5,ErrorMessage ="{0} geen correct getal")]
        public double Rating { get; set; } //op 5

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;


        //1 to many relationship
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }

    }
}
