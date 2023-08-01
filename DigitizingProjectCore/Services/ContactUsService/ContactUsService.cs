using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Net;
using Azure.Core;

namespace DigitizingProjectCore.Services.ContactUsService
{
    public class ContactUsService : IContactUsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper _mapper;
        public ContactUsService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ContactUsViewModel>> GetAll()
        {
            var _contactUs = await _context.ContactUs.Where(x => x.IsDelete == false && x.IsActive == true).OrderBy(x => x.SortId).ToListAsync();
            var _contactUsVM = _mapper.Map<List<ContactUsViewModel>>(_contactUs);
            return _contactUsVM;
        }
        public async Task<List<ContactUsViewModel>> GetAll(string? key)
        {
            var _contactUs = await _context.ContactUs.Where(x => x.IsDelete == false && x.IsActive == true && (string.IsNullOrEmpty(key) || x.Name.Contains(key))).OrderBy(x => x.SortId).ToListAsync();
            var _contactUsVM = _mapper.Map<List<ContactUsViewModel>>(_contactUs);
            return _contactUsVM;
        }
        public async Task<CreateContactUsDto> GetById(int id)
        {
            var _contactUs = await _context.ContactUs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_contactUs == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateContactUsDto>(_contactUs);
            return dto;
        }
        public async Task<CreateContactUsDto> Create(CreateContactUsDto dto)
        {
            var _contactUs = _mapper.Map<ContactUs>(dto);
            var remoteIpAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            _contactUs.IPAddress = remoteIpAddress;
            _contactUs.Date = DateTime.Now.Date;
            _contactUs.IsDelete = false;
            _contactUs.IsActive = true;
            await _context.ContactUs.AddAsync(_contactUs);
            await _context.SaveChangesAsync();
            return dto;
        }


        public async Task<int> Delete(int id)
        {
            var _contactUs = await _context.ContactUs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_contactUs != null)
            {
                _contactUs.IsDelete = true;
                _contactUs.IsActive = false;
                _context.ContactUs.Update(_contactUs);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditReaded(int id , bool isReaded)
        {
            var _contactUs = await _context.ContactUs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_contactUs != null)
            {
                _contactUs.IsReaded = isReaded;
                _context.Update(_contactUs);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
