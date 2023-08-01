using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.SettingService
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SettingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SaveSettingDto> Get()
        {
            var _Setting = await _context.Settings.Where(x => x.key_name.Equals("apply_success")). FirstOrDefaultAsync();
            var dto = _mapper.Map<SaveSettingDto>(_Setting);
            return dto;
        }

        public async Task<SaveSettingDto> Save(SaveSettingDto dto)
        {
            var _Setting = await _context.Settings.Where(x => x.key_name.Equals("apply_success")).FirstOrDefaultAsync();
            if (_Setting == null)
            {
                var _SettingCreate = _mapper.Map<Setting>(dto);
                _SettingCreate.CreatedAt = DateTime.Now;
                _SettingCreate.key_name = "apply_success";
                await _context.Settings.AddAsync(_SettingCreate);
                await _context.SaveChangesAsync();
                return dto;
            }
            var id = _Setting.Id;
            var _SettingUpdate = _mapper.Map(dto, _Setting);
            _SettingUpdate.Id = id;
            _SettingUpdate.UpdatedAt = DateTime.Now;
            _context.Settings.Update(_SettingUpdate);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
