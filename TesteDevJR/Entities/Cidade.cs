using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDevJR.Entities
{
    public class Cidade
    {
        [Key]
        [Display(Name = "Codigo")]
        public int Codigo { get; set; }
        [Required]
        [Display(Name = "Cidade")]
        public string NomeCidade { get; set; }
        [Required]
        [Display(Name = "UF")]
        public string UF { get; set; }
        public string Quantidade { get; set; }
    }
}
