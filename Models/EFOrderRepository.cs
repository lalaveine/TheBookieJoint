using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TheBookieJoint.Models {
    public class EFOrderRepository : IOrderRepository {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext ctx) {
        context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(l => l.Product));

            // Уменьшает количество экземпляров книг(указаных в заказе) на 1
            foreach (var line in order.Lines)
            {
                var product = context.Products.FirstOrDefault(x => x.ProductID == line.Product.ProductID);
                product.NumberOfCopies -= 1;
            }

            if (order.OrderID == 0) {

                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}