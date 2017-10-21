using FritoLay.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FritoLay.Models
{
    public class EFProductRepository : IProductRepository
    {
        FritoLayContext db = new FritoLayContext();

        public EFProductRepository(FritoLayContext connection = null)
        {
            if (connection == null)
            {
                this.db = new FritoLayContext();
            }
            else
            {
                this.db = connection;
            }
        }
        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }
    }
}
