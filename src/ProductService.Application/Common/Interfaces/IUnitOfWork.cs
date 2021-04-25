using System.Threading.Tasks;

namespace ProductService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

         ICategoryRepository CategoryRepository { get; }

        Task Commit();

        Task SaveChanges();

        Task Rollback();

        Task Dispose();
    }
}