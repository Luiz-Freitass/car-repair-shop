using Car_Repair_Shop.Models;

namespace Car_Repair_Shop.Data.Dtos.WorkOrderDto
{
    public class ReadWorkOrderDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int MechanicId { get; set; }
        public required string ProblemDescription { get; set; }
        public required string Service { get; set; }
        public required DateTime EntryDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public double Value { get; set; }
        public WorkOrderStatus Status { get; set; }
    }
}
