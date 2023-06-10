using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketFaith.Models;

namespace MarketFaith.Models
{
    public class LoginResponse
    {
        public User User { get; set; }
        public TokenResponse Token { get; set; }
    }
}
