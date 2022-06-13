using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CompanyContext db) : base(db)
        {

        }

        public IQueryable<CategoryList> GetCategoryList()
        {

            return Set().Select(x => new CategoryList
            {
                CategoryId = x.Id,
                CategoryName = x.CategoryName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == false);
        }
        public IQueryable<CategoryList> CategoryRecover()
        {

            return Set().Select(x => new CategoryList
            {
                CategoryId = x.Id,
                CategoryName = x.CategoryName,
                Deleted = x.Deleted
            }).Where(x => x.Deleted == true);
        }

    }
}
