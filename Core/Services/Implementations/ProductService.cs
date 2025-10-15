using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore.Metadata;
using Services.Abstraction.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ProductService(IUnitOfWorkk _unitOfWorkk,IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandAsync()
        {
            var brands = await _unitOfWorkk.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandsResult=_mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return(brandsResult);
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductAsync()
        {
         var products=await _unitOfWorkk.GetRepository<Product,int>().GetAllAsync ();
            var ProductsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            return(ProductsResult);
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWorkk.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult=_mapper.Map<IEnumerable<TypeResultDto>>(types);
            return typesResult;
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var product =_unitOfWorkk.GetRepository<Product,int>().GetByIdAsync(id);
            var productResult=_mapper.Map<ProductResultDto>(product);
            return (productResult); 
        }
    }
}
