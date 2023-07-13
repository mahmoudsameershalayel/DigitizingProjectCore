using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.NewsService
{
    public interface INewsService
    {
        public Task<List<NewsViewModel>> GetAll();
        public Task<CreateUpdateNewsDto> GetDtoById(int id);
        public Task<News> GetNewsById(int id);
        public Task<CreateUpdateNewsDto> Create(CreateUpdateNewsDto dto);
        public Task<CreateUpdateNewsDto> Update(CreateUpdateNewsDto dto);
        public Task<CreateUpdateNewsDto> InjectCategories();
        public Task<int> Delete(int id);
    }
}
