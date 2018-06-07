using System.Linq;

namespace TheBookieJoint.Models {
    public interface IOrderRepository {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
