using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class AzureOptions
    {
        public string Resourcegroup { get; set; }
        public string Account { get; set;}
        public string Container { get; set; }
        public string StorageConnection { get; set; }
    }
}
