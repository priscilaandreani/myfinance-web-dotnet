using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Domain
{
    public class Account
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}