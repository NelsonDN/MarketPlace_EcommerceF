using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class CurrentUser
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
        public string token { get; set; }

        // Autres propriétés utilisateur que vous souhaitez stocker

        public bool IsLoggedIn => !string.IsNullOrEmpty(token);
    }
}
