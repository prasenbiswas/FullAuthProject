using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Login
    {
        [DefaultValue("abc@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("XXXXXXXX")]
        public string Password { get; set; }
    }
}
