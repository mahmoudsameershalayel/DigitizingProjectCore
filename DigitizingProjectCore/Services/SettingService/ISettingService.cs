using DigitizingProjectCore.Areas.Admin.Dto;

namespace DigitizingProjectCore.Services.SettingService
{
    public interface ISettingService
    {
        public Task<SaveSettingDto> Get();
        public Task<SaveSettingDto> Save(SaveSettingDto dto);
    }
}
