using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain._1.SeparatingReadsFromWrites
{
    // The advantage of this split is that the new interfaces are finer-grained than before.

    // When you create a Decorator that applies a transaction to the executed code, for instance, only IProductCommandServices will need to be decorated, which eliminates the need to implement the IProductQueryServices’s methods.It also makes the implementations smaller and simpler to reason about.

    //Problem: Although this split is an improvement over the original IProductService interface, this new design still causes sweeping changes.As before, implementing a new product-related feature causes a change to many classes in the application.Although you reduced the likelihood of a class being changed by half, a change still causes about the same amount of classes to be touched.This brings us to the second step.
    public interface IProductCommandServices
    {
        void DeleteProduct(Guid productId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateProductReviewTotals(Guid productId, ProductReview[] reviews);
        void AdjustInventory(Guid productId, bool decrease, int quantity);
        void UpdateHasTierPricesProperty(Product product);
        void UpdateHasDiscountsApplied(Guid productId, string discountDescription);
    }
}
