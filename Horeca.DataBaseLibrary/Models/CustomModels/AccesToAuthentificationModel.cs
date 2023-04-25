﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models.CustomModels
{
    public class AccesToAuthentificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAcces { get; set; }
        //[Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 4 and 255 characters", MinimumLength = 4)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
