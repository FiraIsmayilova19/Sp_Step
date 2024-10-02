using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProject.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int BusId { get; set; }
        public Buss Bus { get; set; }
        public string HomeAdress { get; set; }
        public string LicenseNumber { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
