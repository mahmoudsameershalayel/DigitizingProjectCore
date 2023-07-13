using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DigitizingProjectCore.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<UserViewModel>> GetAll()
        {
            var _Users = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();
            var _UsersVM = _mapper.Map<List<UserViewModel>>(_Users);
            return _UsersVM;
        }

        public async Task<CreateUpdateUserDto> GetById(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUpdateUserDto>(_User);
            return dto;
        }
        public async Task<CreateUpdateUserDto> Create(CreateUpdateUserDto dto)
        {
            var _User = _mapper.Map<ApplicationUser>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _User.Created_At = DateTime.Now;
            _User.Created_By = _UserId;
            _User.IsActive = true;
            _User.IsDeleted = false;
            await _userManager.CreateAsync(_User, dto.Password);
            await _userManager.AddToRoleAsync(_User, "Administrator");
           
            return dto;
        }
        public async Task<CreateUpdateUserDto> Update(CreateUpdateUserDto dto)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == dto.Id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            var _UpdatedUser = _mapper.Map(dto, _User);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdatedUser.Updated_at = DateTime.Now;
            _UpdatedUser.Updated_by = _UserId;
            _context.Users.Update(_UpdatedUser);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<int> Delete(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User != null)
            {
                _User.IsDeleted = true;
                _User.IsActive = false;
                _context.Users.Update(_User);
            }
            return await _context.SaveChangesAsync();

        }

        
    }
}
