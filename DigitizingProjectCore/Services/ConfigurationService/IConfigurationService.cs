using DigitizingProjectCore.Areas.Admin.Dto;

namespace DigitizingProjectCore.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        public Task<SaveConfigurationDto> Get();
        public Task<SaveConfigurationDto> Save(SaveConfigurationDto dto);
    }
}
