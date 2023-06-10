using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFaith.Models
{
    public class Enseigne
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; } 
        public string avatar { get; set; }
        public string localisation { get; set; }
        public string prix_livraison { get; set; }
        public string heure_de_livraison { get; set; }
        public string heure_ouverture { get; set; }
        public string heure_fermeture { get; set; }
        public int min_montant { get; set; }

    }
}
