using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents;
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
        public async Task<List<UserViewModel>> GetAll(string? key)
        {
            var _Users = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && (string.IsNullOrEmpty(key) || x.FullName.Contains(key))).ToListAsync();
            var _UsersVM = _mapper.Map<List<UserViewModel>>(_Users);
            return _UsersVM;
        }
        public async Task<CreateUserDto> GetById(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUserDto>(_User);
            return dto;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            return _User;
        }
        public async Task<UpdateUserDto> GetByIdForEdit(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<UpdateUserDto>(_User);
            return dto;
        }
        public async Task<ResetPasswordDto> GetByIdForReset(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<ResetPasswordDto>(_User);
            return dto;
        }
        public async Task<List<Link>> GetLinks()
        {
            var _Links = await _context.Links.ToListAsync();
            return _Links;
        }
        public async Task<CreateUserDto> Create(CreateUserDto dto)
        {
            ApplicationUser _User = new ApplicationUser();
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _User.Created_At = DateTime.Now;
            _User.Created_By = _UserId;
            _User.IsActive = dto.IsActive;
            _User.IsDeleted = false;
            _User.Email = dto.Email;
            _User.UserName = dto.FullName;
            _User.FullName = dto.FullName;
            _User.Phone = dto.Phone;
            var result = await _userManager.CreateAsync(_User, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Username already exist!!");
            }
            await _userManager.AddToRoleAsync(_User, "Administrator");
            return dto;
        }
        public async Task<UpdateUserDto> Update(UpdateUserDto dto)
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
            _UpdatedUser.UserName = dto.FullName;
            _context.Users.Update(_UpdatedUser);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<int> RestPassword(ResetPasswordDto dto)
        {
            if (dto.Password.Equals(dto.ConfirmPassword)) {
                var _User = await _userManager.FindByIdAsync(dto.Id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(_User);
                var result = await _userManager.ResetPasswordAsync(_User, token, dto.Password);
                if (result.Succeeded)
                {
                    return await _context.SaveChangesAsync();
                }
            }
            return 0;

        }
        public async Task<int> Delete(string id)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            if (_User != null)
            {
                _User.IsActive = false;
                _User.IsDeleted = true;
                await _userManager.UpdateAsync(_User);
            }
            return await _context.SaveChangesAsync();

        }

        public async Task<int> UserPremissions(string userId, int[] linkIds)
        {
            var _User = await _context.Users.Where(x => x.IsDeleted == false && x.IsActive == true && x.Id == userId).FirstOrDefaultAsync();
            if (_User != null)
            {
                foreach (var id in linkIds)
                {
                    await _context.AdminLinks.AddAsync(new AdminLinks
                    {
                        AdminId = _User.Id,
                        LinkId = id
                    });
                }
            }
            return await _context.SaveChangesAsync();
        }
    }
}
