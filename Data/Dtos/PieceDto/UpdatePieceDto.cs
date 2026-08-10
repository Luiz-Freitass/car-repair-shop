namespace Car_Repair_Shop.Data.Dtos.PieceDto
{
    public class UpdatePieceDto
    {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
