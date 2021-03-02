using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace backend.Services
{
    public class SupliersServices
    {
        private readonly ApplicationDbContext context;

        public SupliersServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Suppliers.AnyAsync(x => x.SuplierId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return isTrue;
        }

        public async Task<bool> Insert(Suppliers suplier)
        {
            bool isTrue = false;

            try
            {
                context.Add(suplier);
                isTrue = await context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Suppliers suplier)
        {
            bool isTrue = false;

            try
            {
                if (suplier != null)
                {
                    context.Entry(suplier).State = EntityState.Modified;
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
                var isFound = await context.Suppliers.FindAsync(id);

                if (isFound != null)
                {
                    context.Suppliers.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Suppliers> Search(int id)
        {
            Suppliers suplier = new Suppliers();

            try
            {
                suplier = await context.Suppliers.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

            return suplier;
        }
        public async Task<List<Suppliers>> GetList(Expression<Func<Suppliers, bool>> criteria)
        {
            List<Suppliers> list = new List<Suppliers>();

            try
            {
                list = await context.Suppliers.Where(criteria).Include(x => x.Users)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<List<Suppliers>> GetAll()
        {
            List<Suppliers> list = new List<Suppliers>();

            try
            {
                list = await context.Suppliers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
