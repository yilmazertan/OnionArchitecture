using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Persistance.Context;
using OnionArchitecture.Persistance.Repositories.Products;

namespace OnionArchitecture.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductReadRepository ProductsRead =>new ProductReadRepository(_context);

        public async ValueTask DisposeAsync()=> await _context.DisposeAsync();





        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
          return await  _context.SaveChangesAsync(cancellationToken);
        }

         
    }
}
