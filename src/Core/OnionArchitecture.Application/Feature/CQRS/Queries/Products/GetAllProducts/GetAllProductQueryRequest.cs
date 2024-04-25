using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts
{
    public class GetAllProductQueryRequest:IRequest<IList<GetAllProductDto>>
    {
    }
}
