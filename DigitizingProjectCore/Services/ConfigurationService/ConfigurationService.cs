using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public ConfigurationService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<SaveConfigurationDto> Get()
        {
            var _Configuration = await _context.Configurations.FirstOrDefaultAsync();
            var dto = _mapper.Map<SaveConfigurationDto>(_Configuration);
            return dto;
        }

        public async Task<SaveConfigurationDto> Save(SaveConfigurationDto dto)
        {
            var _Configuration = await _context.Configurations.FirstOrDefaultAsync();
            if (_Configuration == null)
            {
                var _ConfigCreate = _mapper.Map<Configuration>(dto);
                await _context.Configurations.AddAsync(_ConfigCreate);
                await _context.SaveChangesAsync();
                return dto;
            }
            var id = _Configuration.Id;
            var _ConfigUpdate = _mapper.Map(dto, _Configuration);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _ConfigUpdate.Id = id;
            _ConfigUpdate.UpdatedBy = _UserId;
            _ConfigUpdate.UpdatedAt = DateTime.Now;
            _context.Configurations.Update(_ConfigUpdate);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
