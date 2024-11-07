using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.IServices
{
    public interface IVariationValueServiceAsync
    {
        Task<int> SaveVariationValueAsync(VariationValueRequestModel model);
        Task<IEnumerable<VariationValueResponseModel>> GetVariationValuesAsync(int variationId);
    }
}
