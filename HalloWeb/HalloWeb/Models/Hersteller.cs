using System.Collections.Generic;

namespace HalloWeb.Models
{
    public class Hersteller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<Stift> Stifte { get; set; } = new HashSet<Stift>();
    }
}