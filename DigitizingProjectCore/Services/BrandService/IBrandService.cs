using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Services.BrandService
{
    public interface IBrandService
    {
        public Task<List<BrandViewModel>> GetAll();
        public Task<List<BrandViewModel>> GetAll(string? key);
        public Task<CreateUpdateBrandDto> GetById(int id);
        public Task<List<BrandViewModel>> GetByName(string name);
        public Task<CreateUpdateBrandDto> Create(CreateUpdateBrandDto dto);
        public Task<CreateUpdateBrandDto> Update(CreateUpdateBrandDto dto);
        public Task<int> Delete(int id);
    }
}
