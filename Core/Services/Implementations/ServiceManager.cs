using AutoMapper;
using Domain.Contracts;
using Services.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implementations
{
    // This class acts as a single access point for all application services.
 // Instead of injecting multiple individual services into controllers,
 // we inject only the ServiceManager, which creates and manages them as needed.

    public class ServiceManager(IUnitOfWorkk _unitOfWork, IMapper _mapper) : IServiceManager

    {
        private readonly Lazy<IProductService> _productService =
             new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService productService => _productService.Value;
    }
}

