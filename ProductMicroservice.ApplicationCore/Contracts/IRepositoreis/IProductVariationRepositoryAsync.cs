using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IRepositoreis
{
    public interface IProductVariationRepositoryAsync : IRepositoryAsync<Product_Variation_Values>
    {
        Task<IEnumerable<Product_Variation_Values>> GetByProductIdAsync(int productId);
    }
}
