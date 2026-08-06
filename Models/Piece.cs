using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Repair_Shop.Models
{
    public class Piece
    {
        public Piece(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ICollection<WorkOrderPiece> WorkOrdersPieces { get; set; } = new HashSet<WorkOrderPiece>();
    }
}
