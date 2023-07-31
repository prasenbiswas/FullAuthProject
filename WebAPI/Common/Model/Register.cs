using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Model
{
    public class Register
    {
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w.+\-]+@gmail\.com$", ErrorMessage = "Please Enter Valid Email.")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DefaultValue("abc@gmail.com")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter, one number and one special character")]
        [Required(ErrorMessage = "Please Enter Mobile Number Password")]
        [DefaultValue("Abc@1234")]
        public string Password { get; set; }

        [Display(Name = "Number")]
        [RegularExpression(@"^(0|\+91)?[789]\d{9}$", ErrorMessage = "Please Enter Valid Mobile Number")]
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [DefaultValue("98XXXXXX78")]
        public string PhoneNumber { get; set; }
    }
}
