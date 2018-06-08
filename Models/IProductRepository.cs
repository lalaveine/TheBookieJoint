using System.Linq;

namespace TheBookieJoint.Models {
    public interface IProductRepository {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}

