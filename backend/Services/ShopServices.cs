using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ShopServices
    {
        private readonly ApplicationDbContext context;

        public ShopServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Shops.AnyAsync(x => x.ShopId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return isTrue;
        }

        public async Task<bool> Insert(Shops shop)
        {
            bool isTrue = false;
            try
            {
                context.Shops.Add(shop);
                isTrue = (await context.SaveChangesAsync() > 0);
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Shops shop)
        {
            bool isTrue = false;

            try
            {
                context.Database.ExecuteSqlRaw($"Delete FROM ShopsDetails where ShopId = {shop.ShopId}");

                foreach (var item in shop.ShopsDetails)
                {
                    context.Entry(item).State = EntityState.Added;
                }

                context.Entry(shop).State = EntityState.Modified;
                isTrue = (await context.SaveChangesAsync() > 0);
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
                var isFound = await context.Shops.FindAsync(id);

                if (isFound != null)
                {
                    context.Shops.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Shops> Search(int id)
        {
            Shops shop = new Shops();

            try
            {
                shop = await context.Shops
                    .Where(x => x.ShopId == id)
                    .Include(s => s.ShopsDetails)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }


            return shop;
        }

        public async Task<List<Shops>> GetList(Expression<Func<Shops, bool>> criteria)
        {
            List<Shops> list = new List<Shops>();

            try
            {
                list = await context.Shops.Where(criteria)
                    .Include(x => x.ShopsDetails).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public async Task<List<Shops>> GetAll()
        {
            List<Shops> list = new List<Shops>();

            try
            {
                list = await context.Shops.Include(x => x.ShopsDetails)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
