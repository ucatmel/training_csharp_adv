using System;
using System.Linq;
using System.Web;

namespace HalloWeb.Models
{
    public class Stift
    {
        public int id { get; set; }
        public virtual Hersteller Hersteller { get; set; }
        public string Farbe { get; set; }
        public string Staerke { get; set; }
        public bool IstWasserfest { get; set; }
    }
}