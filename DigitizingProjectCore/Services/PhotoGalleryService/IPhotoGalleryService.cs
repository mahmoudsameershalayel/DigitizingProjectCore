using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.PhotoGalleryService
{
    public interface IPhotoGalleryService
    {
        public Task<List<PhotoGalleryViewModel>> GetAll();
        public Task<CreateUpdatePhotoGalleryDto> GetById(int id);
        public Task<List<PhotoGalleryViewModel>> Search(string term);
        public Task<CreateUpdatePhotoGalleryDto> Create(CreateUpdatePhotoGalleryDto dto);
        public Task<CreateUpdatePhotoGalleryDto> Update(CreateUpdatePhotoGalleryDto dto);
        public Task<int> Delete(int id);
    }
}
