using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int? RideId { get; set; }
        public Ride Ride { get; set; }
        public string HomeAdress { get; set; }
        public string OtherAdress { get; set; }
    }
}
