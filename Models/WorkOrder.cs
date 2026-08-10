using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car_Repair_Shop.Models
{
    public class WorkOrder
    {
        public WorkOrder(int number, int clientId, int vehicleId, int mechanicId, string problemDescription, string service, DateTime entryDate)
        {
            Number = number;
            ClientId = clientId;
            VehicleId = vehicleId;
            MechanicId = mechanicId;
            ProblemDescription = problemDescription;
            Service = service;
            EntryDate = entryDate;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int ClientId { get; set; }
        public required Client Client { get; set; }
        public int VehicleId { get; set; }
        public required Vehicle Vehicle { get; set; }
        public int MechanicId { get; set; }
        public required Mechanic Mechanic { get; set; }
        public required string ProblemDescription { get; set; }
        public required string Service { get; set; }
        public required DateTime EntryDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public double Value { get; set; }
        public WorkOrderStatus Status { get; set; }
        public ICollection<WorkOrderPiece> Pieces { get; set; } = new HashSet<WorkOrderPiece>();
    }
}
