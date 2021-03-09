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
    public class UsersServices
    {
        private readonly ApplicationDbContext context;

        public UsersServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public async Task<bool> Save(Users user)
        //{
        //    if (user.UserId > 0)
        //        return await Update(user);
        //    else
        //        return await Insert(user);
        //}

        //public async Task<bool> Insert(Users users)
        //{
        //    bool isTrue = false;

        //    try
        //    {
        //        context.Add(users);
        //        isTrue = await context.SaveChangesAsync() > 0;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return isTrue;
        //}

        //public async Task<bool> Update(Users user)
        //{
        //    bool isTrue = false;

        //    try
        //    {
        //        if (user != null)
        //        {
        //            context.Entry(user).State = EntityState.Modified;
        //            isTrue = await context.SaveChangesAsync() > 0;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return isTrue;
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    bool isTrue = false;
        //    try
        //    {
        //        var isFound = await context.Users.FindAsync(id);

        //        if (isFound != null)
        //        {
        //            context.Users.Remove(isFound);
        //            isTrue = (await context.SaveChangesAsync() > 0);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return isTrue;
        //}


        //public async Task<List<Users>> GetList(Expression<Func<Users, bool>> criteria)
        //{
        //    List<Users> list = new List<Users>();

        //    try
        //    {
        //        list = await context.Users.Where(criteria).ToListAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return list;
        //}

        //public async Task<List<Users>> GetList()
        //{
        //    List<Users> list = new List<Users>();

        //    try
        //    {
        //        list = await context.Users.ToListAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return list;
        //}
    }

}
