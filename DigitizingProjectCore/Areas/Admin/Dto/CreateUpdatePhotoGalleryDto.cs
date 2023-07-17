namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdatePhotoGalleryDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SummaryAr { get; set; }
        public string SummaryEn { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile[]? Images { get; set; }
        public string? MainImageName { get; set; }
        public string? ImagesName { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
    }
}
