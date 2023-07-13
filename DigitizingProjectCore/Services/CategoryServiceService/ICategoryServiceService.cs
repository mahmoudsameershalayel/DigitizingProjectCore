using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace DigitizingProjectCore.Services.CategoryServiceService
{
    public interface ICategoryServiceService
    {
        public Task<List<CategoryViewModel>> GetAll();
        public Task<CreateUpdateCategoryDto> GetById(int id);
        public Task<List<CategoryViewModel>> Search(string term);
        public Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto);
        public Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto);
        public Task<int> Delete(int id);
      
    }
}
