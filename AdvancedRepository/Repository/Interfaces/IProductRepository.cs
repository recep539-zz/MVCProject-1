using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IQueryable<ProductList> GetProductList();
        IQueryable<ProductSelect> GetProductSelect();
        IQueryable<ProductList> RecoverProductList();
        IQueryable<ProductList> ListByCategoryId(int id);
        
    }
}
