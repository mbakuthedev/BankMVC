using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankMVC.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}$")]
        public string  Pin { get; set; }
    }
}
