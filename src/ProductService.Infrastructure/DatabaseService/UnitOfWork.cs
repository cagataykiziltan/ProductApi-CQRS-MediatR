using ProductService.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.DatabaseService
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public UnitOfWork(IProductRepository productRepository,
                          ICategoryRepository categoryRepository)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        public async Task Commit()
        {
            //commit
        }

        public async Task SaveChanges()
        {
            //save changes with Dbcontext
        }

        public async Task Rollback()
        {
            //rollback
        }

        public async Task Dispose()
        {
            //dispose
        }
    }
}
