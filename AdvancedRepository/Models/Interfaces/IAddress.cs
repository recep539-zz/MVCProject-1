using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Interfaces
{
    public interface IAddress
    {
        string Street { get; set; }
        string Avenue { get; set; }
        int CountyId { get; set; }
        int OutDoorNumber { get; set; }
        int PhoneNumber { get; set; }
    }
}
