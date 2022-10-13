using MediatR;

namespace JustCommerce.Modules.Identity.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}

