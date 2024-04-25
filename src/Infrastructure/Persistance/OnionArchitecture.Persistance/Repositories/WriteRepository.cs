using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity, new()
    {


        private readonly AppDbContext _context;
        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }


        public async Task<T> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { Table.Remove(entity); });
        }


        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run((() => { Table.Update(entity); }));
            return entity;
        }
    }
}
