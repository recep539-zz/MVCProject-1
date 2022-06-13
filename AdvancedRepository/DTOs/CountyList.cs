using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class CountyList
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public int CityId { get; set; }
        public bool Deleted { get; set; }
    }
}
