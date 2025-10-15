using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductModule
{
    public class Product:BaseEntity<int> //Inheriting the BaseEntity class and specifying the pkey type
    {
        public string Name { get; set; }=null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
      
        //1-M ProductType
        public ProductType ProductType { get; set; }//Navigation Property
        public int TypeId { get; set; }
      
        //1-M ProductBrand
        public ProductBrand ProductBrand { get; set; }//Navigation Property
        public int BrandId { get; set; }

    }
}
