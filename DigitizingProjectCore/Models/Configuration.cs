namespace DigitizingProjectCore.Models
{
    public class Configuration 
    {
        public int Id { get; set; }
        public string FaceBook { get; set; }
        public string Instegram { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string WhatsApp { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string AddressEn { get; set; }
        public string AddressAr { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string IntroEn { get; set; }
        public string IntroAr { get; set; }
        public string ProductsSloganEn { get; set; }
        public string ProductsSloganAr { get; set; }
        public string TrainingSloganEn { get; set; }
        public string TrainingSloganAr { get; set; }
        public string NewsSloganEn { get; set; }
        public string NewsSloganAr { get; set; }
        public string ContactUsSloganEn { get; set; }
        public string ContactUsSloganAr { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
