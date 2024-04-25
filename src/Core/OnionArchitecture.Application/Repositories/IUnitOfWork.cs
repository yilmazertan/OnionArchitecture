using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Repositories
{
    public interface IUnitOfWork:IAsyncDisposable
    {


        IProductReadRepository ProductsRead { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
