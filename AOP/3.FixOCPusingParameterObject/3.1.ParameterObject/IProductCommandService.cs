using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain._3.FixOCPusingParameterObject
{
    // We change the one of each Interface in order to have common Interface 
    public interface IAdjustInventoryService
    {
        void Execute(AdjustInventory command);
    }

    public class AdjustInventory
    {
        public Guid ProductId { get; set; }
        public bool Decrease { get; set; }
        public int Quantity { get; set; }
    }

    public interface IUpdateProductReviewTotalsService
    {
        void Execute(UpdateProductReviewTotals command);
    }

    public class UpdateProductReviewTotals
    {
        public Guid ProductId { get; set; }
        public ProductReview[] Reviews { get; set; }
    }

    // Same refactoring is applied for the rest of interfaces
}
