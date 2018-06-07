using System.Collections.Generic;
using TheBookieJoint.Models;

namespace TheBookieJoint.Models.ViewModels {
    public class ProductsListViewModel {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
 