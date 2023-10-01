using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.Dto.NewsDto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.NewsService
{
    public interface INewsService
    {
        public Task<List<NewsViewModel>> GetAll();
        public Task<List<NewsViewModel>> GetAll(string? key , int? categoryId , bool? isActive);
        public Task<CreateNewsDto> GetDtoById(int id);
        public Task<News> GetNewsById(int id);
        public Task<CreateNewsDto> Create(CreateNewsDto dto);
        public Task<UpdateNewsDto> Update(UpdateNewsDto dto);
        public Task<CreateNewsDto> CreateInjectCategories();
        public Task<UpdateNewsDto> UpdateInjectCategories();
        public Task<int> Delete(int id);
    }

}
