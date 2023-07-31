﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ForgotPasswordViewModel
    {
        [Required,EmailAddress, Display(Name = "Em ail")]
        public string Email { get; set; }
    }
}
