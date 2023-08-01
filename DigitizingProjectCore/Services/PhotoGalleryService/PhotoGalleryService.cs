using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace DigitizingProjectCore.Services.PhotoGalleryService
{
    public class PhotoGalleryService : IPhotoGalleryService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public PhotoGalleryService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<PhotoGalleryViewModel>> GetAll()
        {
            var _Photos = await _context.PhotoGalleries.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).ToListAsync();
            var _PhotosVM = _mapper.Map<List<PhotoGalleryViewModel>>(_Photos);
            return _PhotosVM;
        }
        public async Task<List<PhotoGalleryViewModel>> GetAll(string? key , bool? isActive)
        {
            var _Photos = await _context.PhotoGalleries.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.NameEn.Contains(key) || x.NameAr.Contains(key)) && (isActive == null || x.IsActive == isActive)).OrderBy(x => x.SortId).ToListAsync();
            var _PhotosVM = _mapper.Map<List<PhotoGalleryViewModel>>(_Photos);
            return _PhotosVM;
        }
        public async Task<CreateUpdatePhotoGalleryDto> GetById(int id)
        {
            var _Photo = await _context.PhotoGalleries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Photo == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUpdatePhotoGalleryDto>(_Photo);
            return dto;
        }
        public async Task<List<PhotoGalleryViewModel>> Search(string term)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUpdatePhotoGalleryDto> Create(CreateUpdatePhotoGalleryDto dto)
        {
            var _Photo = _mapper.Map<PhotoGallery>(dto);
            if (dto.MainImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.MainImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.MainImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _Photo.MainImageName = uniqueName;
            }
            if (dto.Images != null)
            {
                var imagesName = "";
                foreach (var Image in dto.Images)
                {
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    imagesName += uniqueName + ",";
                }
                _Photo.ImagesName = imagesName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Photo.Created_By = _UserId;
            _Photo.Created_At = DateTime.Now;
            _Photo.IsDelete = false;
            await _context.PhotoGalleries.AddAsync(_Photo);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<CreateUpdatePhotoGalleryDto> Update(CreateUpdatePhotoGalleryDto dto)
        {
            var _Photo = await _context.PhotoGalleries.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Photo == null)
            {
                throw new Exception("Not Found!!");
            }
            var MainImageName = _Photo.MainImageName;
            var ImagesName = _Photo.ImagesName;
            var _UpdatePhoto = _mapper.Map(dto, _Photo);
            _UpdatePhoto.MainImageName = MainImageName;
            _UpdatePhoto.ImagesName = ImagesName;
            if (dto.MainImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.MainImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.MainImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdatePhoto.MainImageName = uniqueName;
            }
            if (dto.Images != null)
            {
                var imagesName = "";
                foreach (var Image in dto.Images)
                {
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    imagesName += uniqueName + ",";
                }
                _UpdatePhoto.ImagesName = imagesName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdatePhoto.Updated_By = _UserId;
            _UpdatePhoto.Updated_At = DateTime.Now;
            _context.PhotoGalleries.Update(_UpdatePhoto);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Photo = await _context.PhotoGalleries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Photo != null)
            {
                _Photo.IsActive = false;
                _Photo.IsDelete = true;
                _context.PhotoGalleries.Update(_Photo);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteImage(int id, string imageNames)
        {
            var _PhotoGallery =await _context.PhotoGalleries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_PhotoGallery != null) {
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _PhotoGallery.ImagesName = imageNames;
                _PhotoGallery.Updated_At = DateTime.Now;
                _PhotoGallery.Updated_By = _UserId;
                _context.PhotoGalleries.Update(_PhotoGallery);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
