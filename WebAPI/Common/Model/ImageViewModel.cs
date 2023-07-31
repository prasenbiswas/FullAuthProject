using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ImageViewModel
    {
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
