using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain.InitialState
{
    // Small code snippet exhibits three SOLID violations.
    // 1.ISP violation - here’ll be no single consumer of IProductService that’ll use all its methods.Most consumers would typically use one method or a few at most.
    // 2.SRP - ProductService definitely has multiple reasons to change. Not only does ProductService have many reasons to change, its methods are most likely not cohesive.
    //          ¡ Changes to how discounts are applied
    //          ¡ Changes to how inventory adjustments are processed
    //          ¡ Adding search criteria for products
    //          ¡ Adding a new product-related feature
    // 3.OCP - You can expect two quite likely changes to happen during the course of the lifetime of the e-commerce application.First, new features will need to be added(Mary already has them on her backlog). Second, Mary likely also needs to apply Cross-Cutting Concerns. When a new product-related feature is added, the change ripples through all IProductService implementations, which will be the main ProductService implementation, and also all Decorators and Test Doubles.
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
        void DeleteProduct(Guid productId);
        Product GetProductById(Guid productId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        Paged<Product> SearchProducts(int pageIndex, int pageSize, Guid? manufacturerId, string searchText);
        void UpdateProductReviewTotals(Guid productId, ProductReview[] reviews);
        void AdjustInventory(Guid productId, bool decrease, int quantity);
        void UpdateHasTierPricesProperty(Product product);
        void UpdateHasDiscountsApplied(Guid productId, string discountDescription);
    }
}
