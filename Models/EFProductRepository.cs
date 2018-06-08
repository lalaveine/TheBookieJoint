using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheBookieJoint.Models {
    public class EFProductRepository : IProductRepository {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx) {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public void SaveProduct(Product product) {
            if (product.ProductID == 0) {
                context.Products.Add(product);
            } else {
                Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

                if (dbEntry != null) {
                    dbEntry.Name = product.Name;
                    dbEntry.Author = product.Author;
                    dbEntry.Translators = product.Translators;
                    dbEntry.Description = product.Description;
                    dbEntry.OriginalLanguage = product.OriginalLanguage;
                    dbEntry.Language = product.Language;
                    dbEntry.ISBN = product.ISBN;
                    dbEntry.Genre = product.Genre;
                    dbEntry.Publisher = product.Publisher;
                    dbEntry.PublicationYear = product.PublicationYear;
                    dbEntry.NumberOfCopies = product.NumberOfCopies;
                    dbEntry.Price = product.Price;                    
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int productID) {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null) {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}