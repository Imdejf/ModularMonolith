using System.Threading.Tasks;

namespace JustCommerce.Modules.BuildingBlocks.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
}