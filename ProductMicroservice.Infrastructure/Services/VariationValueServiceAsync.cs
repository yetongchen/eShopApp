using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{
    public class VariationValueServiceAsync : IVariationValueServiceAsync
    {
        private readonly IVariationValueRepositoryAsync variationValueRepositoryAsync;
        private readonly IMapper mapper;

        public VariationValueServiceAsync(IVariationValueRepositoryAsync variationValueRepositoryAsync, IMapper mapper)
        {
            this.variationValueRepositoryAsync = variationValueRepositoryAsync;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<VariationValueResponseModel>> GetVariationValuesAsync(int variationId)
        {
            var variationValues = await variationValueRepositoryAsync.GetByVariationIdAsync(variationId);
            return mapper.Map<IEnumerable<VariationValueResponseModel>>(variationValues);
        }

        public async Task<int> SaveVariationValueAsync(VariationValueRequestModel model)
        {
            var variationValue = mapper.Map<Variation_Value>(model);
            return await variationValueRepositoryAsync.InsertAsync(variationValue);
        }
    }
}
