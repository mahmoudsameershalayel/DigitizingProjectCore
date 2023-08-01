using DigitizingProjectCore.Areas.Admin.Dto;

namespace DigitizingProjectCore.Services.AboutUsService
{
    public interface IAboutUsService
    {
        public Task<SaveAboutUsDto> Get();
        public Task<SaveAboutUsDto> Save(SaveAboutUsDto dto);
    }
}
