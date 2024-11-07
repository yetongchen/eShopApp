﻿using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ProductDbContext context;

        public BaseRepositoryAsync(ProductDbContext context)
        {
            this.context = context;
        }
        public async Task<int> InsertAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if (result != null)
            {
                context.Set<T>().Remove(result);
                return await context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> UpdateAsync(T entity)
        {
            context.Set<T>().Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
