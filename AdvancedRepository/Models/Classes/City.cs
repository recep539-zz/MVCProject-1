using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class City:Base
    {
        public City()
        {
            Counties = new HashSet<County>();
        }
        public string CityName { get; set; }
        public ICollection<County> Counties { get; set; }
    }
}
