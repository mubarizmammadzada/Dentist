using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Недействительный номер телефона")]
        public string PhoneNumber { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]

        public string Messsage { get; set; }
    }
}
