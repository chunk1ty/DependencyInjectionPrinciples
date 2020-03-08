using System;
using System.Collections.Generic;
using System.Text;

namespace AOP.Domain._1.SeparatingReadsFromWrites
{
    // The advantage of this split is that the new interfaces are finer-grained than before.
    public interface IProductQueryServices
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
        Product GetProductById(Guid productId);
        Paged<Product> SearchProducts(int pageIndex, int pageSize, Guid? manufacturerId, string searchText);
    }
}
