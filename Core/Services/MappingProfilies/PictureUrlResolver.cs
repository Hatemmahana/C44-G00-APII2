using AutoMapper;
using Domain.Entities.ProductModule;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

namespace Services.MappingProfiles
{
    public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductResultDto, string>
    {
        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
            // (src => $"https://localhost:7079/{src.PictureUrl}")
            if (string.IsNullOrEmpty(source.PictureUrl)) return string.Empty;
            return $"{_configuration.GetSection("URLS")["BaseURL"]}{source.PictureUrl}";
        }
    }
}