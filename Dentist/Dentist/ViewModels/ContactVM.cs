using Dentist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewModels
{
    public class ContactVM
    {
        //public string Name { get; set; }
        //[Required, DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
        //[Required]
        //public string Subject { get; set; }
        //[Required]
        //public string Messagge { get; set; }
        //[Required, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Недействительный номер телефона")]
        //public string PhoneNumber { get; set; }
        public Bio  Bio { get; set; }
        public Message Message { get; set; }

    }
}