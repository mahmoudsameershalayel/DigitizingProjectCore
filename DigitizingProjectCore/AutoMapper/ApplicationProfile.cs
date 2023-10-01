using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.Dto.NewsDto;
using DigitizingProjectCore.Areas.Admin.Dto.ProductDto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //User
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();


            //Service
            CreateMap<Service, CreateUpdateServiceDto>().ReverseMap();
            CreateMap<Service , ServiceViewModel>().ReverseMap();
            CreateMap<Service, AddServiceWithCategory>().ReverseMap();


            //CategoryForService
            CreateMap<CategoryForService, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForService, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CreateUpdateCategoryDto>().ReverseMap();


            //Product
            CreateMap<Product , CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product , ProductViewModel>().ReverseMap();
            CreateMap<Product , AddProductWithCategoryAndBrand>().ReverseMap();
            CreateMap<Product, EditProductWithCategoryAndBrand>().ReverseMap();

            //CategoryForProduct
            CreateMap<CategoryForProduct , CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForProduct , CategoryViewModel>().ReverseMap();


            //News
            CreateMap<News, CreateNewsDto>().ReverseMap();
            CreateMap<News, UpdateNewsDto>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();


            //PhotoGallery
            CreateMap<PhotoGallery, CreateUpdatePhotoGalleryDto>().ReverseMap();
            CreateMap<PhotoGallery, PhotoGalleryViewModel>().ReverseMap();


            //CategoryForNews
            CreateMap<CategoryForNews, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForNews, CategoryViewModel>().ReverseMap();

            //Solution 
            CreateMap<Solution , CreateUpdateSolutionDto>().ReverseMap();
            CreateMap<Solution , SolutionViewModel>().ReverseMap();
            CreateMap<Solution, AddSolutionWithCategoryAndBrandAndProduct>().ReverseMap();


            //JobApplication
            CreateMap<JobApplication, CreateJobApplicationDto>().ReverseMap();
            CreateMap<JobApplication, JobApplicationViewModel>().ReverseMap();
            CreateMap<JobApplication, AddJobApplicationWithJMD>().ReverseMap();


            //Brand
            CreateMap<Brand , CreateUpdateBrandDto>().ReverseMap();
            CreateMap<Brand , BrandViewModel>().ReverseMap();


            //City
            CreateMap<City , CityViewModel>().ReverseMap();


            //Job
            CreateMap<Job, CreateUpdateJobDto>().ReverseMap();
            CreateMap<Job, JobViewModel>().ReverseMap();


            //Distributor
            CreateMap<Distributor , DistributorViewModel>().ReverseMap();
            CreateMap<Distributor , CreateUpdateDistributorDto>().ReverseMap();
            CreateMap<Distributor, AddDistibutorWithCity>().ReverseMap();


            //Page
            CreateMap<Page, CreateUpdatePageDto>().ReverseMap();
            CreateMap<Page, PageViewModel>().ReverseMap();


            //Configuration
            CreateMap<Configuration, SaveConfigurationDto>().ReverseMap();


            //AboutUs
            CreateMap<AboutUs, SaveAboutUsDto>().ReverseMap();


            //Setting
            CreateMap<Setting, SaveSettingDto>().ReverseMap();


            //ContactUs
            CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, ContactUsViewModel>().ReverseMap();


            //HomePageBanner
            CreateMap<HomePageBanner, CreateUpdateHomePageDto>().ReverseMap();
            CreateMap<HomePageBanner, HomePageViewModel>().ReverseMap();
        }
    }
}
