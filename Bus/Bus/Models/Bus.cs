using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProject.Models
{
    public class Buss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int SeatCount { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
