using System.Linq;

namespace TheBookieJoint.Models {
    public interface IProductRepository {
        IQueryable<Product> Products { get; }
    }
}

