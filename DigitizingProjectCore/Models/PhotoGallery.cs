namespace DigitizingProjectCore.Models
{
    public class PhotoGallery : BaseEntity
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string MainImageName { get; set; }
        public int SortId { get; set; }
        public string SummaryEn { get; set; }
        public string SummaryAr { get; set; }
        public string ImagesName { get; set; }
    }
}
