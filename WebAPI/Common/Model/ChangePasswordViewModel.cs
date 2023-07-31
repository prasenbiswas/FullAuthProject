using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Model
{
    public class ChangePasswordViewModel
    {
        [Required,DataType(DataType.Password),Display(Name="Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password"), Display(Name = "New Password"), DefaultValue("Abc@1234"), DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter, one number and one special character")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password"), Display(Name = "Confirm New Password"), DefaultValue("Abc@1234"), DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Confirm New Password does not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
