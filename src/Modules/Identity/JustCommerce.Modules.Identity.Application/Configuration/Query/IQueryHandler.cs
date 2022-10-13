using JustCommerce.Modules.Identity.Application.Contracts;
using MediatR;

namespace JustCommerce.Modules.Identity.Application.Configuration.Query
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
