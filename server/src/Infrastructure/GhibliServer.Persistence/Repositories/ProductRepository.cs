using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Domain.Entities;
using GhibliServer.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext):base(appDbContext)
        {
           
        }

        public async Task IsDeletedAsync(Guid id)
        {
            var product = await _appDbContext.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            product.IsDeleted = true;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
