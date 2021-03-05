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
    public class SalesServies
    {
        private readonly ApplicationDbContext context;

        public SalesServies(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Sales.AnyAsync(x => x.SalesId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return isTrue;
        }

        public async Task<bool> Insert(Sales sale)
        {
            bool isTrue = false;
            try
            {
                context.Sales.Add(sale);
                //ProductosBLL.DisminuirInventario(ventas);
                isTrue = (await context.SaveChangesAsync() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            
            return isTrue;
        }

        public async Task<bool> Update(Sales sale)
        {
            bool isTrue = false;

            try
            {
                context.Database.ExecuteSqlRaw($"Delete FROM SalesDetails where SaleId = {sale.SalesId}");

                foreach (var item in sale.SalesDetails)
                {
                    context.Entry(item).State = EntityState.Added;
                }

                context.Entry(sale).State = EntityState.Modified;
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
                var isFound = await context.Sales.FindAsync(id);

                if (isFound != null)
                {
                    context.Sales.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return isTrue;
        }

        public async Task<Sales> Search(int id)
        {
            Sales sale = new Sales();

            try
            {
                sale = await context.Sales
                    .Where(x => x.SalesId == id)
                    .Include(d => d.SalesDetails)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
            

            return sale;
        }

        public async Task<List<Sales>> GetList(Expression<Func<Sales, bool>> criteria)
        {
            List<Sales> list = new List<Sales>();

            try
            {
                list = await context.Sales.Where(criteria)
                    .Include(x=> x.SalesDetails).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
            return list;
        }

        public async Task<List<Sales>> GetAll()
        {
            List<Sales> list = new List<Sales>();

            try
            {
                list = await context.Sales.Include(x=> x.SalesDetails)
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