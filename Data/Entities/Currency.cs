using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Data
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Unit { get; set; }

        public decimal ConversionFactor { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
