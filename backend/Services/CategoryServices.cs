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
    public class CategoryServices
    {
        private readonly ApplicationDbContext context;

        public CategoryServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Categories.AnyAsync(x=> x.CategoryId == id);
            }
            catch (Exception)
            {

                throw;
            }
            
            return isTrue;
        }

        public async Task<bool> Insert(Categories category)
        {
            bool isTrue = false;

            try
            {
                context.Add(category);
                isTrue = await context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Categories category)
        {
            bool isTrue = false;

            try
            {
                if (category != null)
                {
                    context.Entry(category).State = EntityState.Modified;
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
                var isFound = await context.Categories.FindAsync(id);

                if (isFound != null)
                {
                    context.Categories.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Categories> Search(int id)
        {
            Categories category = new Categories();

            try
            {
                category = await context.Categories.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

            return category;
        }
        public async Task<List<Categories>> GetList(Expression<Func<Categories, bool>> criteria)
        {
            List<Categories> list = new List<Categories>();

            try
            {
                list = await context.Categories.Where(criteria).Include(x => x.User)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<List<Categories>> GetAll()
        {
            List<Categories> list = new List<Categories>();

            try
            {
                list = await context.Categories.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}