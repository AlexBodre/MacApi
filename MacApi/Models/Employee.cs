using System;
using System.ComponentModel.DataAnnotations;

namespace MacApi.Models
{
    public class Employee
    {
        
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apelllido { get; set; }
        public int Edad { get; set; }
        [Required]
        public DateTime FechaContrato { get; set; }


    }
}
