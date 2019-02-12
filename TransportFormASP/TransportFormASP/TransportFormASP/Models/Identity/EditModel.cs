using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models.Identity
{
    public class EditModel
    {
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email исполнителя")]
        public string Email { get; set; }
    }
}