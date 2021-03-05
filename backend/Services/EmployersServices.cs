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
    public class EmployersServices
    {
        private readonly ApplicationDbContext context;
        public EmployersServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            var isTrue = false;
            try
            {
                isTrue = await context.Employers.AnyAsync(e => e.EmployerId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return isTrue;
        }
        public async Task<bool> Insert(Employers employer)
        {
            bool isTrue = false;

            try
            {
                context.Employers.Add(employer);
                isTrue = await context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<bool> Update(Employers employer)
        {
            bool isTrue = false;

            try
            {
                if (employer != null)
                {
                    context.Entry(employer).State = EntityState.Modified;
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
                var isFound = await context.Employers.FindAsync(id);

                if (isFound != null)
                {
                    context.Employers.Remove(isFound);
                    isTrue = (await context.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTrue;
        }

        public async Task<Employers> Search(int id)
        {
            Employers employer = new Employers();

            try
            {
                //employer = await context.Employers.FindAsync(id);
                employer = await context.Employers.Where(e => e.EmployerId == id)
                    .Include(u => u.Users).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return employer;
        }
        public async Task<List<Employers>> GetList(Expression<Func<Employers, bool>> criteria)
        {
            List<Employers> list = new List<Employers>();

            try
            {
                list = await context.Employers.Where(criteria).Include(u => u.Users)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<List<Employers>> GetAll()
        {
            List<Employers> list = new List<Employers>();

            try
            {
                list = await context.Employers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }

}
