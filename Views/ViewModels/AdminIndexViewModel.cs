using System.Collections.Generic;
using TheBookieJoint.Models;

namespace TheBookieJoint.Models.ViewModels {
    public class AdminIndexViewModel {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentSortOrder { get; set; }
        public string SearchString { get; set ;}
    }
}
 