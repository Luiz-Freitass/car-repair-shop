using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car_Repair_Shop.Models
{
    public class Mechanic
    {
        public Mechanic(string name, string specialty, string contact)
        {
            Name = name;
            Specialty = specialty;
            Contact = contact;
        }

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public required string Contact { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; } = new HashSet<WorkOrder>();
    }
}
