using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Services
{
    public class ProductsServices
    {
        private readonly ApplicationDbContext context;

        public ProductsServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Products.AnyAsync(x => x.ProductId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return isTrue;
        }

        public async Task<bool> Insert(Products product)
        {
            bool isTrue = false;

            try
            {
                context.Products.Add(product);
                isTrue = await context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Products product)
        {
            bool isTrue = false;

            try
            {
                if (product != null)
                {
                    context.Entry(product).State = EntityState.Modified;
                    isTrue = await context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Delete(int id)
        {
            bool isTrue = false;
            try
            {
                var isFound = await context.Products.FindAsync(id);

                if (isFound != null)
                {
                    context.Products.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Products> Search(int id)
        {
            Products suplier = new Products();

            try
            {
                suplier = await context.Products.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

            return suplier;
        }

        public async Task<List<Products>> GetList(Expression<Func<Products, bool>> criteria)
        {
            List<Products> list = new List<Products>();

            try
            {
                list = await context.Products.Where(criteria).Include(c => c.Categories)
                    .Include(s => s.Suppliers).Include(u => u.Users).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<List<Products>> GetAll()
        {
            List<Products> list = new List<Products>();

            try
            {
                list = await context.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
