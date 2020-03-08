using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain._2.FixISPandSRPbySplitingInterfaceAndImplementation
{
    // The initial impression my be that's not a good idea. What I did is just move each method in separate interface/classes. It looks more complicated and I have more code to maintain. But there are some advantages:
    //      ¡ Every interface is segregated.No client will be forced to depend on methods it  doesn’t use.
    //      ¡ When you create a one-to-one mapping from interface to implementation,  each use case in the application gets its own class. This makes classes small and
    //      focused — they have a single responsibility.
    //      ¡ Adding a new feature means the addition of a new interface-implementation  pair.No changes have to be made to existing classes that implement other  use cases.

    //Problem: This new design causes each class in the application to be focused around one particular use case, which is great from the perspective of the SRP and the ISP.But, because these classes have no commonality to which you can apply aspects, you’re forced to create many Decorators with almost identical implementations. It’d be nice if you were able to define a single interface for all command operations in the code base. That would greatly reduce the code duplication around aspects and the number of Decorator classes to one Decorator per aspect.
    public interface IAdjustInventoryService
    {
        void AdjustInventory(Guid productId, bool decrease, int quantity);
    }

    public interface IUpdateProductReviewTotalsService
    {
        void UpdateProductReviewTotals(Guid productId, ProductReview[] reviews);
    }

    public interface IUpdateHasDiscountsAppliedService
    {
        void UpdateHasDiscountsApplied(Guid productId, string discountDescription);
    }

    public interface IInsertProductService
    {
        void InsertProduct(Product product);
    }

    public interface IDeleteProductService
    {
        void DeleteProduct(Guid productId);
    }

    public interface IUpdateProductService
    {
        void UpdateProduct(Product product);
    }

    public interface IUpdateHasTierPricesPropertyService
    {
        void UpdateHasTierPricesProperty(Product product);
    }
}
