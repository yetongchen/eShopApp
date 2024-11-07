using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IRepositoreis
{
    public interface IVariationValueRepositoryAsync : IRepositoryAsync<Variation_Value>
    {
        Task<IEnumerable<Variation_Value>> GetByVariationIdAsync(int variationId);
    }
}
