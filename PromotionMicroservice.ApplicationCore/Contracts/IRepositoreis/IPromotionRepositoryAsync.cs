using PromotionMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionMicroservice.ApplicationCore.Contracts.IRepositoreis
{
    public interface IPromotionRepositoryAsync : IRepositoryAsync<Promotion>
    {
        Task<IEnumerable<Promotion>> GetPromotionsByProductCategoryNameAsync(string productCategoryName);
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    }
}
